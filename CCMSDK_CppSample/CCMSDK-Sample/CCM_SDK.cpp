/*************************************************************************
*
* Copyright (c) 2010-2017 Citrix Systems, Inc. All Rights Reserved.
* You may only reproduce, distribute, perform, display, or prepare derivative works of this file pursuant to a valid license from Citrix.
*
* THIS SAMPLE CODE IS PROVIDED BY CITRIX "AS IS" AND ANY EXPRESS OR IMPLIED
* WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
* MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
*
*************************************************************************/

#include <windows.h>
#include <algorithm>
#include <sstream>
#include <vector>
#include "CCMSDK.h"

//#define CCM_OK                    (0x0000)
//#define CCM_SUCCEEDED(rr)         (CCM_OK == rr)
#define CCM_INVALID_SESSION_ID    (-1)
#define CCM_LAP_ICA_FILE_PATH     "ICA_FILE_PATH"
#define CCM_LAP_PARAM             "PARAM"
#define CCM_LAP_ICA_FILE_URL      "ICA_FILE_URL"
#define CCM_LAP_TRUSTEDLAUNCHER   "TRUSTEDLAUNCHER"
//#define CCM_ERROR_DEAD            (0xFFF4)

#define LAUNCHER_NAME	"MY-LAUNCHER-NAME"	//define this, e.g. SSP uses 'Dazzle', no checked by default, can be whitelisted
#ifdef _WIN32
#define CCM_CALL_CONV __stdcall
#else
#define CCM_CALL_CONV
#endif




CCMSDK::CCMSDK(void) :  m_CCMSDKLoaded( false ), m_CCMSDK( 0 )
{
    wchar_t ICAInstallFolder[ 4096 ] = {0};
    // Try to load the CCMSDK.
    HKEY hKey( 0 );
    RegOpenKeyExW( HKEY_LOCAL_MACHINE, L"Software\\Citrix\\Install\\ICA Client", 0, KEY_READ, &hKey );
    if (!hKey)
    {
        RegOpenKeyExW( HKEY_CURRENT_USER, L"Software\\Citrix\\Install\\ICA Client", 0, KEY_READ, &hKey );
    }
    if (hKey)
    {
        DWORD bytesRead = sizeof( ICAInstallFolder );
        RegQueryValueExW( hKey, L"InstallFolder", 0, 0, (LPBYTE) &ICAInstallFolder[0], &bytesRead );
        RegCloseKey( hKey );
    }

    if ( wcslen( ICAInstallFolder ) )
    {
        std::wstring ccmsdk( ICAInstallFolder );
        ccmsdk += L"CCMSDK.DLL";
        m_CCMSDK = LoadLibrary( ccmsdk.c_str() );
        if ( m_CCMSDK )
        {
            m_pCCMInitialize = (pfnCCMInitialize)GetProcAddress( m_CCMSDK, "CCMInitialize" );
            m_pCCMUninitialize = (pfnCCMUninitialize)GetProcAddress( m_CCMSDK, "CCMUninitialize" );
            m_pCCMLaunchApp = (pfnCCMLaunchApp)GetProcAddress( m_CCMSDK, "CCMLaunchApplication" );
            m_pCCMEnumerateSessions = (pfnCCMEnumerateSessions)GetProcAddress( m_CCMSDK, "CCMEnumerateSessions" );
            m_pCCMGetSessionInfo = (pfnCCMGetSessionInfo)GetProcAddress( m_CCMSDK, "CCMGetSessionInfo" );
            m_pCCMFreeICASession = (pfnCCMFreeICASession)GetProcAddress( m_CCMSDK, "CCMFreeICASession" );
            m_pfnCCMDisconnectUserSessions = (pfnCCMDisconnectUserSessions)GetProcAddress(m_CCMSDK, "CCMDisconnectUserSessions");
            m_pfnCCMFullScreenSession = (pfnCCMFullScreenSession)GetProcAddress(m_CCMSDK, "CCMFullScreenSession");

        }
        if ( !m_pCCMInitialize || !m_pCCMUninitialize || !m_pCCMLaunchApp 
                               || !m_pCCMEnumerateSessions || !m_pCCMGetSessionInfo
                               || !m_pCCMFreeICASession
                               )
            {
                //dbg_trace(Error) << L"CCMSDK load failed." << std::endl;
            }
            else
            {
                // Initialize CCMSDK.
                if ( 0 == m_pCCMInitialize(LAUNCHER_NAME) )
                    m_CCMSDKLoaded = true;
            }
    }
}


CCMSDK::~CCMSDK(void)
{
    if ( m_CCMSDKLoaded )
        m_pCCMUninitialize();

    if ( m_CCMSDK )
        FreeLibrary( m_CCMSDK );
}


// Launch an ICA session based on an ICA file received by another purpose
// icaFilePath - file path to ICA file used for launch (utf8)
// cmdLine - any command line params have to go here, not in ICA File (utf8)
// obtainedURL - URL of service from which ICA file was obtained, can allow lockdown (utf8)
CCMResult CCMSDK::CCMLaunch(CCMChar *icaFilePath, CCMChar *cmdLine, CCMChar *obtainedURL )
{
    if (!m_CCMSDKLoaded)
        return CCM_INVALID_SESSION_ID;

    CCMSessionID sessionId = CCM_INVALID_SESSION_ID;
    CCM_Name_Value_Pair launchParams[4] = {0}; // 4 seperate pieces of data to pass

    launchParams[0].Name = CCM_LAP_ICA_FILE_PATH;
    launchParams[0].Value = icaFilePath;
    launchParams[1].Name = CCM_LAP_PARAM;
    launchParams[1].Value = cmdLine;
    launchParams[2].Name = CCM_LAP_ICA_FILE_URL;
    launchParams[2].Value = obtainedURL;
    launchParams[3].Name = CCM_LAP_TRUSTEDLAUNCHER;
    launchParams[3].Value = LAUNCHER_NAME;

    CCMResult result = m_pCCMLaunchApp(4, launchParams, &sessionId);

    if(result == CCM_ERROR_DEAD)
    {
        // PNA retries in a loop, repeatedly re-initializing the dll. We
        // will just fail the launch, but uninitialize the dll, so it will be
        // re-initialized next time.
        if(CCM_SUCCEEDED(m_pCCMUninitialize()))
        {
            m_CCMSDKLoaded = false;
        }
    }

    return result;

}

// Enumerate the set of active ICA sessions
// pCount - pointer to a var that will receive the number of available sessions
// ppICASessions - pointer to a var that will receive the address of an array of session structs
//      NB: release this data when done by calling CCMFreeICASession(count, ppICASessions)
// Returns: CCM_OK - session info found
//          CCM_ERROR_SESSION_NOT_FOUND - no sessions
//
CCMResult CCMSDK::CCMEnumerateSessions(unsigned long* pCount, PCCM_ICASession* ppICASessions)
{
    if (!m_CCMSDKLoaded)
        return CCM_INVALID_SESSION_ID;
    return (m_pCCMEnumerateSessions(pCount, ppICASessions));
}

// Get info on a specific active ICA session
// hSession - session ID
// ppICASession - pointer to a var that will receive the address a session structs
//      NB: release this data when done by calling CCMFreeICASession(1, ppICASession)
// Returns: CCM_OK - session info found
//          CCM_ERROR_SESSION_NOT_FOUND - no sessions
//
CCMResult CCMSDK::CCMGetSessionInfo(CCMSessionID hSession, PCCM_ICASession* ppICASession)
{
    if (!m_CCMSDKLoaded)
        return CCM_INVALID_SESSION_ID;
    return (m_pCCMGetSessionInfo(hSession, ppICASession));
}

// Free session data obtained by the above
void CCMSDK::CCMFreeICASession(unsigned long count, PCCM_ICASession pSessions)
{
    if (m_CCMSDKLoaded)
        m_pCCMFreeICASession(count, pSessions);
}

CCMResult CCMSDK::CCMDisconnectUserSessions(const CCMChar* pUsernName, const CCMChar* pDomainName)
{
    if (m_CCMSDKLoaded)
        return m_pfnCCMDisconnectUserSessions(pUsernName, pDomainName);
}

CCMResult CCMSDK::CCMFullScreenSession(CCMSessionID hSession)
{
    if (m_CCMSDKLoaded)
        return m_pfnCCMFullScreenSession(hSession);
}


