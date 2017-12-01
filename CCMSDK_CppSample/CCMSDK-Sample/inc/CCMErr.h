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

#define CCM_OK                               (0x0000)

#define CCM_ERROR_BASE                       (0xFFFF)
#define CCM_ERROR_UNEXPECTED                 (0xFFFF)
#define CCM_ERROR_UNINITIALIZED              (0xFFFE)
#define CCM_ERROR_COMMUNICATION              (0xFFFD)
#define CCM_ERROR_OUT_OF_MEMORY              (0xFFFC)
#define CCM_ERROR_INVALID_ARGUMENT           (0xFFFB)
#define CCM_ERROR_AUTHORIZATION_FAILED       (0xFFFA)
#define CCM_ERROR_CONNECTION_NOT_FOUND       (0xFFF9)
#define CCM_ERROR_SESSION_NOT_FOUND          (0xFFF8)
#define CCM_ERROR_APPLICATION_NOT_FOUND      (0xFFF7)
#define CCM_ERROR_ATTRIBUTE_NOT_FOUND        (0xFFF6)
#define CCM_ERROR_SRP_NOT_ENABLED            (0xFFF5)
#define CCM_ERROR_DEAD                       (0xFFF4)
#define CCM_ERROR_INITIALIZATION_FAILED      (0xFFF3)
#define CCM_ERROR_ALREADY_INITIALIZED        (0xFFF2)
#define CCM_ERROR_BOTTOM                     (0xF000)

#define CCMSE_ERROR_BASE                     (0xEFFF)
#define CCMSE_ERROR_WINDOW_POSITION          (0xEFFF)
#define CCMSE_ERROR_RESIZING_APPLICATION     (0xEFFE)
#define CCMSE_ERROR_DRIVER_NOT_LOADED        (0xEFFD)
#define CCMSE_ERROR_PROPERTY                 (0xEFFC)
#define CCMSE_ERROR_SCALING                  (0xEFFB)
#define CCMSE_ERROR_KB                       (0xEFFA)
#define CCMSE_ERROR_MOUSE                    (0xEFF9)
#define CCMSE_ERROR_HEADLESS_DISABLED        (0xEFF8)
#define CCMSE_ERROR_POST_MESSAGE		     (0xEFF7)
#define CCMSE_ERROR_BOTTOM                   (0xE000)

#define CCM_CLIENT_ERROR_BASE                (0x3FFF)
#define CCM_CLIENT_RSTRAY_ERROR              (0x3FFE)
#define CCM_CLIENT_ERROR_BOTTOM              (0x0001)

#define CCM_SUCCEEDED(hResult)               (hResult == CCM_OK)
#define CCM_FAILED(hResult)                  (hResult != CCM_OK)

#define IS_CCM_ERROR(hResult)                ((CCM_ERROR_BASE >= hResult && hResult >= CCM_ERROR_BOTTOM) || (CCMSE_ERROR_BASE >= hResult && hResult >= CCMSE_ERROR_BOTTOM))
#define IS_CLIENT_ERROR(hResult)             (CCM_CLIENT_ERROR_BASE >= hResult && hResult >= CCM_CLIENT_ERROR_BOTTOM)