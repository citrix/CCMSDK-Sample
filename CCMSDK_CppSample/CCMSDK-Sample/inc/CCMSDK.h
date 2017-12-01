/*************************************************************************
*
* Copyright (c) 2008-2017 Citrix Systems, Inc. All Rights Reserved.
* You may only reproduce, distribute, perform, display, or prepare derivative works of this file pursuant to a valid license from Citrix.
*
* THIS SAMPLE CODE IS PROVIDED BY CITRIX "AS IS" AND ANY EXPRESS OR IMPLIED
* WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
* MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
*
*************************************************************************/

#pragma once

#include <CCMTypes.h>
#include <CCMAttr.h>
#include <CCMEvent.h>
#include <CCMErr.h>


#ifdef __cplusplus
extern "C" {
#endif

typedef void* CCMConnectionEventContext;
typedef void* CCMSessionStateEventContext;
typedef void* CCMSessionSharingEventContext;
typedef void* CCMSessionErrorEventContext;
typedef void* CCMApplicationEventContext;

typedef void (CCM_CALL_CONV *CCMConnectionEventCallbackFP)(CCMConnectionEventContext, CCMConnectionID, CCMClientEventID);
typedef void (CCM_CALL_CONV *CCMSessionStateEventCallbackFP)(CCMSessionStateEventContext, CCMSessionID, CCMSessionStateEventID);
typedef void (CCM_CALL_CONV *CCMSessionSharingEventCallbackFP)(CCMSessionSharingEventContext, CCMSessionID, CCMSessionID, CCMSessionSharingEventID);
typedef void (CCM_CALL_CONV *CCMSessionErrorEventCallbackFP)(CCMSessionErrorEventContext, CCMSessionID, unsigned long, CCMSessionErrorEventID, CCMChar* pErrMsg);
typedef void (CCM_CALL_CONV *CCMApplicationEventCallbackFP)(CCMApplicationEventContext, CCMSessionID, CCMApplicationID, CCMApplicationEventID);

typedef struct _CCM_Name_Value_Pair_
{
    IDL_STRING CCMChar* Name;
    IDL_STRING CCMChar* Value;
} CCM_Name_Value_Pair, *PCCM_Name_Value_Pair;

typedef struct _CCM_ICASession_
{
    CCMSessionID        SessionID;
    CCMConnectionID     ConnectionID;
    IDL_STRING CCMChar* FriendlyName;
    IDL_STRING CCMChar* NonSeamlessAppTitle;
    unsigned long       IsFullScreen;
    unsigned long       Ssl;
    IDL_STRING CCMChar* EncryptionLevel;
    IDL_STRING CCMChar* EngineVersion;
    IDL_STRING CCMChar* ServerName;
    IDL_STRING CCMChar* UserName;
    IDL_STRING CCMChar* DomainName;
    unsigned long       RxFrameCount;
    unsigned long       TxFrameCount;
    unsigned long       RxByteCount;
    unsigned long       TxByteCount;
    unsigned long       RxFrameErrorCount;
    unsigned long       TxFrameErrorCount;
    unsigned long       SeamlessMode;
    unsigned long       ZlMode;
    unsigned long       CGP;
    unsigned long       SpeedBrowseEnabled;
    unsigned long       LastLatency;
    unsigned long       AverageLatency;
    unsigned long       RoundTripDeviation;
    unsigned long       HRes;
    unsigned long       VRes;
    unsigned long       ColorDepth;
    unsigned long       AudioEnabled;
    unsigned long       PdaEnabled;
    unsigned long       TwnEnabled;
    unsigned long       PnpEnabled;
} CCM_ICASession, *PCCM_ICASession;

typedef struct _CCM_ICAApplication_
{
    CCMApplicationID    ApplicationID;
    CCMSessionID        SessionID;
    IDL_STRING CCMChar* FriendlyName;
    IDL_STRING CCMChar* Title;
    IDL_STRING CCMChar* ClassName;
    unsigned long       IconSize;
#ifdef CCM_IDL
    [size_is(IconSize)]
#endif
    unsigned char*      IconData;
        unsigned long       hIcon;
} CCM_ICAApplication, *PCCM_ICAApplication;

typedef struct _CCM_RSApplication_
{
    CCMPid              ProcessID;
    CCMSessionID        SessionID;
    IDL_STRING CCMChar* FriendlyName;
//    unsigned long       IconSize;
//#ifdef CCM_IDL
//    [size_is(IconSize)]
//#endif
//    unsigned char*      IconData;
//    unsigned long       hIcon;
} CCM_RSApplication, *PCCM_RSApplication;

typedef unsigned char *CCMMemory;
typedef const unsigned char *CCMCMemory;

CCMResult CCM_CALL_CONV CCMInitialize(const CCMChar* pConnectionName);
CCMResult CCM_CALL_CONV CCMUninitialize();
CCMResult CCM_CALL_CONV CCMGetCCMAttributes(unsigned long* pCount, PCCM_Name_Value_Pair* ppAttributes);

CCMResult CCM_CALL_CONV CCMGetMyConnectionID(CCMConnectionID* pCCMConnectionID);
CCMResult CCM_CALL_CONV CCMEnumerateConnections(unsigned long* pCount, CCMConnectionID** ppConnections);

CCMResult CCM_CALL_CONV CCMSetConnectionAttributes(CCMConnectionID hConnection, unsigned long count, const PCCM_Name_Value_Pair pAttributes);
CCMResult CCM_CALL_CONV CCMGetConnectionAttributes(CCMConnectionID hConnection, unsigned long* pCount, PCCM_Name_Value_Pair* ppAttributes);
CCMResult CCM_CALL_CONV CCMDeleteConnectionAttribute(CCMConnectionID hConnection, const PCCM_Name_Value_Pair pAttribute);

CCMResult CCM_CALL_CONV CCMLaunchApplication(unsigned long count, const PCCM_Name_Value_Pair pParams, CCMSessionID* hSession);
CCMResult CCM_CALL_CONV CCMLaunchPublishedApplication(CCMSessionID hSession, const CCMChar* pAppName, const CCMChar* pArguments);
CCMResult CCM_CALL_CONV CCMEnumerateApplications(unsigned long* pCount, PCCM_ICAApplication* ppICAApplications);
CCMResult CCM_CALL_CONV CCMGetApplicationInfo(CCMApplicationID hApplication, PCCM_ICAApplication* ppICAApplication);
CCMResult CCM_CALL_CONV CCMTerminateApplication(CCMApplicationID hApplication);
CCMResult CCM_CALL_CONV CCMSendLaunchRequestToServer(CCMSessionID hSession, unsigned long size, const CCMChar* pLaunchInfo, CCMBool* pbRedirected);

CCMResult CCM_CALL_CONV CCMEnumerateRSApplications(unsigned long* pCount, PCCM_RSApplication* ppRSApplications);
CCMResult CCM_CALL_CONV CCMTerminateRSApplication(CCMPid Pid);
CCMResult CCM_CALL_CONV CCMGetSessionForRSApplicationPid(CCMPid Pid, CCMSessionID* phSession);
CCMResult CCM_CALL_CONV CCMGetSessionForRSApplicationWindow(CCMWindowID hWindow, CCMSessionID* phSession);

CCMResult CCM_CALL_CONV CCMSetSessionAttributes(CCMSessionID hSession, unsigned long count, const PCCM_Name_Value_Pair pAttributes);
CCMResult CCM_CALL_CONV CCMGetSessionAttributes(CCMSessionID hSession, unsigned long* pCount, PCCM_Name_Value_Pair* ppAttributes);
CCMResult CCM_CALL_CONV CCMDeleteSessionAttribute(CCMSessionID hSession, const PCCM_Name_Value_Pair pAttribute);

CCMResult CCM_CALL_CONV CCMEnumerateSessions(unsigned long* pCount, PCCM_ICASession* ppICASessions);
CCMResult CCM_CALL_CONV CCMGetSessionInfo(CCMSessionID hSession, PCCM_ICASession* ppICASession);
CCMResult CCM_CALL_CONV CCMDisconnectSession(CCMSessionID hSession);
CCMResult CCM_CALL_CONV CCMLogoffSession(CCMSessionID hSession);
CCMResult CCM_CALL_CONV CCMDisconnectAllSessions();
CCMResult CCM_CALL_CONV CCMLogoffAllSessions();
CCMResult CCM_CALL_CONV CCMFullScreenSession(CCMSessionID hSession);

CCMResult CCM_CALL_CONV CCMSystrayIconMessage(CCMApplicationID hApplication, unsigned long message, unsigned long XPos, unsigned long YPos);
CCMResult CCM_CALL_CONV CCMGetSecurityInfo(CCMSessionID hSession, unsigned long *pDataSize, unsigned char **ppSecurityData);
CCMResult CCM_CALL_CONV CCMSetSecurityInfo(CCMSessionID hSession, unsigned long dataSize, const unsigned char *pSecurityData);
CCMResult CCM_CALL_CONV CCMForeGroundApplication(CCMApplicationID hApplication);

CCMResult CCM_CALL_CONV CCMGetErrorMessageStringForCode(CCMSessionID hSession, unsigned long errorCode, CCMChar** ppErrorString);

CCMResult CCM_CALL_CONV CCMGetActiveSessionCount(unsigned long *pCount);

CCMResult CCM_CALL_CONV CCMSubscribeConnectionEvents(CCMConnectionEventCallbackFP fp, CCMConnectionEventContext pContext);
CCMResult CCM_CALL_CONV CCMSubscribeSessionStateEvents(CCMSessionStateEventCallbackFP fp, CCMSessionStateEventContext pContext);
CCMResult CCM_CALL_CONV CCMSubscribeSessionSharingEvents(CCMSessionSharingEventCallbackFP fp, CCMSessionSharingEventContext pContext);
CCMResult CCM_CALL_CONV CCMSubscribeSessionErrorEvents(CCMSessionErrorEventCallbackFP fp, CCMSessionErrorEventContext pContext);
CCMResult CCM_CALL_CONV CCMSubscribeApplicationEvents(CCMApplicationEventCallbackFP fp, CCMApplicationEventContext pContext);

CCMResult CCM_CALL_CONV CCMAllocMemory(CCMMemory *lppMemory, unsigned long ulSizeInBytes);
void CCM_CALL_CONV CCMFreeNameValuePair(unsigned long count, PCCM_Name_Value_Pair pNVP);
void CCM_CALL_CONV CCMFreeICASession(unsigned long count, PCCM_ICASession pSession);
void CCM_CALL_CONV CCMFreeICAApplication(unsigned long count, PCCM_ICAApplication pApplication);
void CCM_CALL_CONV CCMFreeRSApplication(unsigned long count, PCCM_RSApplication pApplication);
void CCM_CALL_CONV CCMFreeMemory(void *pVoid);

CCMResult CCM_CALL_CONV CCMGetUnmarshalledHeadlessInterface(CCMSessionID hSession, void* pIID, void** ppISession);
CCMResult CCM_CALL_CONV CCMDisconnectUserSessions(const CCMChar* pUsernName, const CCMChar* pDomainName);
CCMResult CCM_CALL_CONV CCMGetActiveSessionCountForUser(const CCMChar* pUserName, const CCMChar* pDomainName, unsigned long *pCount);

CCMResult CCM_CALL_CONV CCMSendTrayNotification( unsigned short usDataSizeInBytes, CCMCMemory lpData );

#ifdef __cplusplus
}
#endif

// C++ class to encapsulate the dynamic load of the DLL into some simplified interfaces
typedef CCMResult (CCM_CALL_CONV *pfnCCMInitialize)( const CCMChar* pConnectionName );
typedef CCMResult (CCM_CALL_CONV *pfnCCMUninitialize)( void );
typedef CCMResult (CCM_CALL_CONV *pfnCCMLaunchApp)(unsigned long count, const PCCM_Name_Value_Pair pParams, CCMSessionID* hSession);
typedef CCMResult (CCM_CALL_CONV *pfnCCMEnumerateSessions)(unsigned long* pCount, PCCM_ICASession* ppICASessions);
typedef CCMResult (CCM_CALL_CONV *pfnCCMGetSessionInfo)(CCMSessionID hSession, PCCM_ICASession* ppICASession);
typedef void      (CCM_CALL_CONV *pfnCCMFreeICASession)(unsigned long count, PCCM_ICASession pSession);

typedef CCMResult (CCM_CALL_CONV *pfnCCMGetActiveSessionCountForUser)(const CCMChar* pUserName, const CCMChar* pDomainName, unsigned long *pCount);

typedef CCMResult (CCM_CALL_CONV *pfnCCMDisconnectUserSessions) (const CCMChar* pUsernName, const CCMChar* pDomainName);

typedef CCMResult (CCM_CALL_CONV *pfnCCMFullScreenSession) (CCMSessionID hSession);



class CCMSDK
{
    public:
        CCMSDK(void);
        ~CCMSDK(void);

        CCMResult CCMSDK::CCMLaunch(CCMChar *, CCMChar *, CCMChar * );
        CCMResult CCMSDK::CCMEnumerateSessions(unsigned long*, PCCM_ICASession*);
        CCMResult CCMSDK::CCMGetSessionInfo(CCMSessionID, PCCM_ICASession*);
        void      CCMSDK::CCMFreeICASession(unsigned long count, PCCM_ICASession pSession);

        CCMResult CCMSDK::CCMDisconnectUserSessions(const CCMChar* pUsernName, const CCMChar* pDomainName);


        CCMResult CCMSDK::CCMFullScreenSession(CCMSessionID hSession);

    private:
            HMODULE m_CCMSDK;
            bool m_CCMSDKLoaded;
            pfnCCMInitialize    m_pCCMInitialize;
            pfnCCMUninitialize  m_pCCMUninitialize;
            pfnCCMLaunchApp     m_pCCMLaunchApp;
            pfnCCMEnumerateSessions m_pCCMEnumerateSessions;
            pfnCCMGetSessionInfo m_pCCMGetSessionInfo;
            pfnCCMFreeICASession m_pCCMFreeICASession;
            pfnCCMDisconnectUserSessions m_pfnCCMDisconnectUserSessions;
            pfnCCMFullScreenSession m_pfnCCMFullScreenSession;
};




