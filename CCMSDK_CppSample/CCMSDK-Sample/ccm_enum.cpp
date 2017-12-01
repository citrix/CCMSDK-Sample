/*************************************************************************
*
* Copyright (c) 2017 Citrix Systems, Inc. All Rights Reserved.
* You may only reproduce, distribute, perform, display, or prepare derivative works of this file pursuant to a valid license from Citrix.
*
* THIS SAMPLE CODE IS PROVIDED BY CITRIX "AS IS" AND ANY EXPRESS OR IMPLIED
* WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
* MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
*
*************************************************************************/

#include <stdio.h>
#include <Windows.h>
#include "CCMSDK.h"
#include "tchar.h"

int _tmain(int argc, _TCHAR* argv[])
{

    CCMSDK ccmsdk;

    unsigned long count;
    PCCM_ICASession sesslist;

    CCMResult xxx = ccmsdk.CCMEnumerateSessions(&count, &sesslist);

    if (CCM_OK == xxx)
    {
        printf("CCM enum sessions (Null) sess count:%d\n", count);
        for (int l = 0; l < count; l++)
        {
            ccmsdk.CCMFullScreenSession(sesslist[l].SessionID);
            printf("Sess %x User:%s AppTitle: %s\n", sesslist[l].SessionID, sesslist[l].UserName, sesslist[l].NonSeamlessAppTitle);
        }
    }
    else
        if (CCM_ERROR_SESSION_NOT_FOUND == xxx)
            printf("No Sessions detected\n");
        else
            printf("CCM enum sessions (Null) failed, err:%#x\n", xxx);

    ccmsdk.CCMDisconnectUserSessions( "kundankuma1", "citrite" );

    ccmsdk.CCMFreeICASession(count, sesslist);

    return 0;
}

