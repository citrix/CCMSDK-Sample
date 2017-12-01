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

typedef enum _CCMClientEventID_
{
    CCMClientEvent_Invalid    = -1,
    CCMClientEvent_Connect    = 0,
    CCMClientEvent_Disconnect = 1
} CCMClientEventID;

typedef enum _CCMSessionStateEventID_
{
    CCMSessionStateEvent_Invalid                      = -1,
    CCMSessionStateEvent_Created                      = 0,
    CCMSessionStateEvent_ConnectFailed                = 1,
    CCMSessionStateEvent_InvalidLicense               = 2,
    CCMSessionStateEvent_RefusedByEarlyAuthentication = 3,
    CCMSessionStateEvent_UserCancelled                = 4,
    CCMSessionStateEvent_ResolvingApp                 = 5,
    CCMSessionStateEvent_Connecting                   = 6,
    CCMSessionStateEvent_Connected                    = 7,
    CCMSessionStateEvent_LogOn                        = 8,
    CCMSessionStateEvent_LogOnFailed                  = 9,
    CCMSessionStateEvent_Initialized                  = 10,
    CCMSessionStateEvent_Terminated                   = 11,
    CCMSessionStateEvent_FullScreen                   = 12,
    CCMSessionStateEvent_SeamlessMode                 = 13,
    CCMSessionStateEvent_Hidden                       = 14,
    CCMSessionStateEvent_Displayed                    = 15,
    CCMSessionStateEvent_CGPWarn                      = 16,
    CCMSessionStateEvent_CGPUnwarn                    = 17,
    CCMSessionStateEvent_CGPDisconnectWarn            = 18,
    CCMSessionStateEvent_CGPDisconnect                = 19,
    CCMSessionStateEvent_CGPReconnect                 = 20,
    CCMSessionStateEvent_ACRReconnecting              = 21,
    CCMSessionStateEvent_ACRReconnected               = 22,
    CCMSessionStateEvent_ACRReconnectFailed           = 23,
    CCMSessionStateEvent_PublishedAppLaunched         = 24,
    CCMSessionStateEvent_PublishedAppLaunchFailed     = 25,
    CCMSessionStateEvent_SecurityPolicyChanged        = 26,
    CCMSessionStateEvent_NewDesktopInfo				  = 27
} CCMSessionStateEventID;

typedef enum _CCMSessionSharingEventID_
{
    CCMSessionSharingEvent_Invalid = -1,
    CCMSessionSharingEvent_Success = 0
} CCMSessionSharingEventID;

typedef enum _CCMSessionErrorEventID_
{
    CCMSessionErrorEvent_Invalid = -1,
    CCMSessionErrorEvent_Error = 0
} CCMSessionErrorEventID;

typedef enum _CCMApplicationEventID_
{
    CCMApplicationEvent_Invalid             = -1,
    CCMApplicationEvent_Launch              = 0,
    CCMApplicationEvent_Terminate           = 1,
    CCMApplicationEvent_TitleChanged        = 2,
    CCMApplicationEvent_IconChanged         = 3
} CCMApplicationEventID;

#ifdef __cplusplus
}
#endif
