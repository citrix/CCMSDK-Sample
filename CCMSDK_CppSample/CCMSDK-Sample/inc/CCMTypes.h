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

#ifdef __cplusplus
extern "C" {
#endif

#ifdef _WIN32
#define CCM_CALL_CONV __stdcall
#else
#define CCM_CALL_CONV
#endif

#ifdef CCM_IDL
#define IDL_STRING [string]
#else
#define IDL_STRING
#endif

typedef long CCMResult;
typedef char CCMBool;
typedef char CCMChar;            // UTF8
typedef long CCMConnectionID;
typedef long CCMSessionID;
typedef long CCMApplicationID;
typedef long CCMPid;
typedef unsigned int CCMWindowID;

#define CCM_INVALID_SESSION_ID (-1)

// Used in CCMPrivateSE_GetSecuritySettings, and set version in ICO
typedef enum _CCMSecurityOption_
{
    CCMSecurityOption_NoSelection = 0,
    CCMSecurityOption_FileAccess  = 1,
    CCMSecurityOption_AudioAccess = 2,
    CCMSecurityOption_PDAAccess   = 3,
    CCMSecurityOption_TWNAccess   = 4,
    CCMSecurityOption_FlashAccess = 5
} CCMSecurityOption;

#ifdef __cplusplus
}
#endif
