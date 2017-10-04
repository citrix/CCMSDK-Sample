# /*************************************************************************
# *
# * THIS SAMPLE CODE IS PROVIDED "AS IS" AND ANY EXPRESS OR IMPLIED
# * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
# * MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
# *
# *************************************************************************/

<#
	This is the powershell library contains functions that wraps around the C# Module of CCMSDK	
#>

<#
    .SYNOPSIS
        Initializes the CCM SDK
    .DESCRIPTION
        Initializes the CCM SDK
    .PARAMETER    
        No parameter
#>

function CCMInitialize{ 
    $initialize = [CCMSDKAPI.CCM]::new('CCMSDK Sample')
    $returnVal = $initialize.ccmInitializeResult
    if($returnVal -eq 65522){
        Write-Host "CCM already initialized"
    }
    elseif($returnVal -ne 0){
        write-host "CCM Initialization Failed with Error code $returnVal"
        throw "CCM Initialization Failed"
    }
    Write-Host "CCM Initialization successful"  
    return $initialize
}

<#
    .SYNOPSIS
        Uninitializes the CCM SDK
    .DESCRIPTION
        Uninitializes the CCM SDK
    .PARAMETER    
        No parameter
#>

function CCMUninitialize{
    Write-Host "Uninitialyzing the CCM Session"
    [CCMSDKAPI.UnsafeNativeMethods]::CCMUninitialize()
    if($ret -ne 0){
        write-host "CCM Uninitialization Failed with Error code $ret"
        throw "CCM Initialization Failed"
    }
}

<#
    .SYNOPSIS
        Disconnects user session belonging to username
    .DESCRIPTION
        Disconnects user session belonging to username
    .PARAMETER    
        Username
        DomainName
#>

function CCMDisconnectUserSession{
    param(
        [parameter(Mandatory=$true)][string]$UserName,
        [parameter(Mandatory=$true)][string]$DomainName
    )
    $ret = $initialize.CCMDisconnectUserSession($UserName,$DomainName);
    if($ret -ne 0){
        write-host "Disconnect All Sessions Failed with Error code $ret"
        throw "CCMDisconnectAllSessions Failed"
    }
    Write-Host "Disconnect user session Passed"
}

<#
    .SYNOPSIS
        Logsoff session belonging to username
    .DESCRIPTION
        Logsoff session belonging to username
    .PARAMETER    
        Username
        DomainName
#>

function CCMDisconnectUserSession{
    param(
        [parameter(Mandatory=$true)][string]$UserName,
        [parameter(Mandatory=$true)][string]$DomainName
    )
    $ret = $initialize.CCMDisconnectUserSession($UserName,$DomainName);
    if($ret -ne 0){
        write-host "Disconnect All Sessions Failed with Error code $ret"
        throw "CCMDisconnectAllSessions Failed"
    }
    Write-Host "Disconnect user session Passed"
}


<#
    .SYNOPSIS
        Disconnects all the user sessions that are active 
    .DESCRIPTION
        Disconnects all the user sessions that are active
    .PARAMETER    
#>
function CCMDisconnectAllSessions{
    Write-Host "Disconnecting all session"
    $ret = $initialize.CCMDisconnectAllSessions()
    if($ret -ne 0){
        write-host "Disconnect All Sessions Failed with Error code $ret"
        throw "CCMDisconnectAllSessions Failed"
    }
    Write-Host "Disconnect all session Passed"
}

<#1
    .SYNOPSIS
        Logs off all the sessions that are active
    .DESCRIPTION
        Logs off all the sessions that are active
    .PARAMETER    
#>
function CCMLogoffAllSessions{
    Write-Host "Logging off all sessions"
    $ret =  $initialize.CCMLogoffAllSessions()
    if($ret -ne 0){
        Write-Host "Logoff all session failed with error code $ret"
        throw "CCMLogoffAllSessions Failed"
    }
}

<#
    .SYNOPSIS
        Gets the list of all the session along with details that are active
    .DESCRIPTION
        Gets the list of all the session along with details that are active
    .PARAMETER    
#>
function CCMEnumerateSessions{
    Write-Host "Get the details of all the launched sesions"
    $ccmIcaSessions = @()
    $retVal = $initialize.CCMEnumerateSessions([ref]$ccmIcaSessions)
    if($retVal){
        Write-Host "Failed Enumerating the sessions - $retVal"
        throw "CCMEnumerateSessions Failed"
    }
    Write-Host "Able to get Session details"
    $ccmIcaSessions
    Write-Host "-----------------------------------------------------------"
    return $ccmIcaSessions
}


<#
    .SYNOPSIS
        Verifies the Session details returned by CCMEnumerateSessions against array of Hashtable 
    .DESCRIPTION
        Verifies the Session details returned by CCMEnumerateSessions against array of Hashtable 
    .PARAMTER
        SessionDetails - HashTable
#>

function VerifyCCMSessionEnumeration{
    param(
        [parameter(Mandatory=$false)][hashtable[]]$SessionDetails
    )
    $ccmIcaSessions = CCMEnumerateSessions
    $count = 0
    Write-Host "Iterating the list of Hash Tables"
    foreach($hash in $SessionDetails){
        $res = IsHashSubSetOfObject -hash $hash -SessionDetails $ccmIcaSessions
        if($res){
            $count++
        }
    }
    if($count -eq $SessionDetails.count){
        Write-Host "CCM Enumeration function returned proper  result" 
    }
    else{
        Write-Host "Failed Verifying the session details" 
        throw "CCMEnumerateSessions Verification Failed"
    }
}

<#
    .SYNOPSIS
        Gets the list of all the Application session along with details that are active
    .DESCRIPTION
        Gets the list of all the Application session along with details that are active
    .PARAMETER    
#>
function CCMEnumerateApplications{
    Write-Host "Get the details of all the launched applications"
    $ccmIcaSessions = @()
    $retVal = $initialize.CCMEnumerateApplications([ref]$ccmIcaSessions)
    if($retVal){
        Write-Host "Failed Enumerating the sessions - $retVal"
        throw "CCMEnumerateSessions Failed"
    }
    Write-Host "Able to get Session details"
    $ccmIcaSessions
    return $ccmIcaSessions
}

<#
    .SYNOPSIS
        Verifies the Application details returned by CCMEnumerateApplications against array of Hashtable 
    .DESCRIPTION
        Verifies the Application details returned by CCMEnumerateApplications against array of Hashtable 
    .PARAMTER
        SessionDetails - Array of HashTable
    .EXAMPLE
        VerifyCCMApplicationEnumeration -SessionDetails (@{'FriendlyName'='App1'},@{'FriendlyName'='App2'}

        Hash Table Keys are
        ApplicationID 
        SessionID     
        FriendlyName  
        Title         
        ClassName     
        IconSize      
        IconData      
        hIcon         
#>

function VerifyCCMApplicationEnumeration{
    param(
        [parameter(Mandatory=$false)][hashtable[]]$SessionDetails
    )
    $count = 0
    $ccmIcaSessions = CCMEnumerateApplications
    Write-Host "Iterating the list of Hash Tables"
    foreach($hash in $SessionDetails){
        $res = IsHashSubSetOfObject -hash $hash -SessionDetails $ccmIcaSessions
        if($res){
            $count++
        }
    }
    if($count -eq $SessionDetails.count){
        Write-Host "CCM Enumeration function returned proper result" 
    }
    else{
        Write-Host "Failed Verifying the session details" 
        throw "CCMEnumerateSessions Verification Failed"
    }
}

<#
    .SYNOPSIS
        Terminates the required application
    .DESCRIPTION
        Terminates the required application
    .PARAMETER    
        ApplicationName
#>
function CCMTerminateApplication{
    param(
        [parameter(Mandatory=$true)][String]$ApplicationName
    )
    $ccmAppList = CCMEnumerateApplications
    foreach($obj in $ccmAppList){
        if($obj.FriendlyName -eq $ApplicationName){
            $ApplicationId = $obj.ApplicationID
            break
        } 
    }
    if([string]::IsNullOrEmpty($ApplicationId)){
        throw "Not able to get application id"
    }
    #$appId = RetrieveDataFromObj -0bject $ccmAppList -Key -Value -RequiredKey
    $retVal = $initialize.CCMTerminateApplication($ApplicationId)
    if($retVal){
        Write-Host "Error terminating the application"
    }
    Write-Host "CCMTerminateApplication Successfull"
}

<#
    .SYNOPSIS
        Logsoff/Disconnects the Desktop 
    .DESCRIPTION
        Logsoff/Disconnects the Desktop 
    .PARAMETER    
        DesktopName
        Operation - Logoff/Disconnect
#>
function CCMSessionOperation{
    param(
        [parameter(Mandatory=$true)][String]$DesktopName,
        [parameter(Mandatory=$false)][ValidateSet("Logoff","Disconnect")][String]$Operation
    )
    $ccmSessionList = CCMEnumerateSessions
    foreach($obj in $ccmSessionList){
        if($obj.NonSeamlessAppTitle -eq $DesktopName){
            $SessionId = $obj.SessionID
            break
        } 
    }
    if([string]::IsNullOrEmpty($SessionId)){
        throw "Not able to get Session id"
    }
    if($Operation -eq 'Logoff'){
        $retVal = $initialize.CCMLogoffSession($SessionId)
    }
    else{
        $retVal = $initialize.CCMDisconnectSession($SessionId)
    }
    Write-Host "Session Id - $SessionId"
    if($retVal){
        Write-Host "Error $Operation session $DesktopName"
        throw "CCMSessionOperation failed"
    }
    Write-Host "CCMSessionOperation $Operation Successfull"
}

<#
    .SYNOPSIS
        Retrives the required Value of Key from Set of Objects
    .DESCRIPTION
        Retrives the required Value of Key from Set of Objects
    .PARAMETER    
        Objects
        Key
        Value
        RequiredKey
#>
function RetrieveDataFromObj{
    param(
        [parameter(Mandatory=$true)][Object]$0bjects,        
        [parameter(Mandatory=$true)][String]$Key,
        [parameter(Mandatory=$true)][String]$Value,
        [parameter(Mandatory=$true)][String]$RequiredKey
    )
    foreach($obj in $Objects){
        if($obj.$Key -eq $Value){
            return $obj.$RequiredKey
        } 
    }
}


<#
    .SYNOPSIS
        Checks if One hash table is subset of a Object
    .DESCRIPTION
        Checks if One hash table is subset of a Object
    .PARAMETER    
        HashTable
        Object
#>

function IsHashSubSetOfObject{
    param(
        [parameter(Mandatory=$true)][hashtable]$hash,
        [parameter(Mandatory=$true)]$SessionDetails
    )
    foreach($details in $SessionDetails){
        $found = $true
        foreach($key in $hash.Keys){
            $value = $hash.$key
            if($details.$key -ne $value){
                $found = $false
            } 
        }
        if($found){
            return $true
        }
    }
    return $false
}

<#
    .SYNOPSIS
        Gets the Application Details of launched application
    .DESCRIPTION
        Gets the Application Details of launched application
    .PARAMETER    
        No Parameter
#>
function CCMGetApplicationInfo{
    $ccmAppSession = CCMEnumerateApplications
    foreach($ccmSession in $ccmAppSession){
        $ApplicationId = $ccmSession.ApplicationID
        $ccmObj = New-Object CCMSDKAPI.CCM_ICAApplication
        $res = $initialize.CCMGetApplicationInfo($ApplicationId,[ref]$ccmObj)
        if($ccmSession -ne $ccmObj){
            write-host "CCMGetApplicationInfo not getting right information"
            throw "CCMGetApplicationInfo Failed"
        }
        Write-Host "Application info matched"
    }
}

<#
    .SYNOPSIS
        Gets the Session Details of launched application/Desktop
    .DESCRIPTION
        Gets the Session Details of launched application/Desktop
    .PARAMETER    
#>
function CCMGetSessionInfo{
    $ccmAppSession = CCMEnumerateSessions
    foreach($ccmSession in $ccmAppSession){
        $SessionID = $ccmSession.SessionID
        Write-Host $SessionID
        $ccmObj = New-Object CCMSDKAPI.CCM_ICASession
        $res = $initialize.CCMGetSessionInfo($SessionID,[ref]$ccmObj)
        if($ccmSession -ne $ccmObj){
            write-host "CCMGetApplicationInfo not getting right information"
            throw "CCMGetSessionInfo Failed"
        }
        Write-Host "Application info matched"
    }
}

<#
    .SYNOPSIS
        Gets the Session Details of launched application/Desktop with extra info related to cert
    .DESCRIPTION
        Gets the Session Details of launched application/Desktop with extra info related to cert
    .PARAMETER    
        NonSeamlessAppTitle 
#>
function CCMGetSessionInfo_V2{
    param(
        [parameter(Mandatory=$true)][string]$NonSeamlessAppTitle
    )
    $ccmAppSession = CCMEnumerateSessions
    foreach($ccmSession in $ccmAppSession){
        if($ccmSession.NonSeamlessAppTitle -eq $NonSeamlessAppTitle){
            $SessionID = $ccmSession.SessionID
            Write-Host $SessionID
            $ccmObj = New-Object CCMSDKAPI.CCM_ICASession_V2
            $retVal = $initialize.CCMGetSessionInfo_V2($SessionID,[ref]$ccmObj)
            Write-Host $retVal
            if($retVal -eq 0){
                return $ccmObj
            }
            else{
                Write-Host "CCMGetSessionInfo_V2 returned with $retVal"
                throw "CCMGetSessionInfo_V2 failed"
            }
        }
    }
    Write-Host "No application/Desktop found with NonSeamlessAppTitle as title"
    throw "CCMGetSessionInfo_V2 Failed"
}

<#
    .SYNOPSIS
        Gets the Session Details of launched application/Desktop
    .DESCRIPTION
        Gets the Session Details of launched application/Desktop
    .PARAMETER    
        NonSeamlessAppTitle 
        SessionDetails  - Hashtable
    .EXAMPLE
        VerifySessionInfo_V2 -NonSeamlessAppTitle App1 -SessionDetails {'IsFullScreen'=1}

        Hash Table keys are
        SessionID                     : -50476147
        ConnectionID                  : 2
        FriendlyName                  : DPKZY-TSVDA-1
        NonSeamlessAppTitle           : Calc_DPKZY-TSVDA-1 - Citrix Receiver
        IsFullScreen                  : 0
        Ssl                           : 0
        EncryptionLevel               : Basic
        EngineVersion                 : Ver 14.9.0.185
        ServerName                    : DPKZY-TSVDA-1
        UserName                      : Administrator
        DomainName                    : bvt.local
        RxFrameCount                  : 105
        TxFrameCount                  : 74
        RxByteCount                   : 22557
        TxByteCount                   : 5548
        RxFrameErrorCount             : 0
        TxFrameErrorCount             : 0
        SeamlessMode                  : 1
        ZlMode                        : 0
        CGP                           : 1
        SpeedBrowseEnabled            : 0
        LastLatency                   : 2
        AverageLatency                : 2
        RoundTripDeviation            : 2
        HRes                          : 136
        VRes                          : 64
        ColorDepth                    : 24
        AudioEnabled                  : 1
        PdaEnabled                    : 0
        TwnEnabled                    : 1
        PnpEnabled                    : 1
        NewUrlRedirectionEnabled      : 0
        SSLLSDKComplianceMode         : 
        ConnectionInfoProtocolVersion : 
        ConnectionInfoCipherSuite     : 
        PeerCertificateCount          : 4294967295
        Certificate0TempPath          : 
        CertificateTempPath           : 
        CertificateBuffer             : 0
#>
function VerifySessionInfo_V2{
    param(
        [parameter(Mandatory=$true)][string]$NonSeamlessAppTitle,
        [parameter(Mandatory=$true)][hashtable]$SessionDetails
    )
    Write-Host "Getting the session info"
    $ccmObj = CCMGetSessionInfo_V2 -NonSeamlessAppTitle $NonSeamlessAppTitle
    foreach($key in $SessionDetails.Keys){
        if($ccmObj.$key -ne $SessionDetails.$key){
            Write-Host "Expected value of $key - "+ $SessionDetails.$key
            Write-Host "Observed value of $key - "+ $ccmObj.$key
            throw "Session details is not as expected"
        }
    }
    Write-Host "Session details verified"
}

<#
    .SYNOPSIS
        Gets the connection Id of CCM
    .DESCRIPTION
        Gets the connection Id of CCM
    .PARAMETER
        No Parameter    
#>
function CCMGetMyConnectionID{
    Write-Host "Getting the Connection Id"
    $a = New-Object System.Int32
    $initialize.CCMGetMyConnectionID([ref]$a)
    return $a
}

<#
    .SYNOPSIS
        Switches a application to Full Screen mode 
    .DESCRIPTION
        Switches a application to Full Screen mode 
    .PARAMETER    
        ApplicationName
#>
function CCMFullScreenSession{
    param(
        [parameter(Mandatory=$true)][String]$ApplicationName
    )
    $ccmSessionList = CCMEnumerateApplications
    foreach($obj in $ccmSessionList){
        if($obj.FriendlyName -eq $ApplicationName){
            $SessionId = $obj.SessionID
            break
        } 
    }
    if([string]::IsNullOrEmpty($SessionId)){
        throw "Not able to get Session id"
    }
    $retVal = $initialize.CCMFullScreenSession($SessionId)
    Write-Host "Session Id - $SessionId"
    if($retVal){
        Write-Host "Error Full screening the Desktop"
    }
    Write-Host "CCMFullScreenSession Successfull"

}

<#
    .SYNOPSIS
        Launches the application by taking the Name Value Pair which consists of details such as ICA file
    .DESCRIPTION
        Launches the application by taking the Name Value Pair which consists of details such as ICA file
    .PARAMETER    
        NameValuePair 
    .EXAMPLE
        CCMLaunchApplication -NameValuePair @{'ICA_FILE_PATH'='Path_To_Ica_File'}
#>
function CCMLaunchApplication{
    param(
        [parameter(Mandatory=$true)][hashtable]$NameValuePair
    )
    $count = $NameValuePair.Keys.Count
    $CCM_NameValuePair = @()

    Write-Host "Iterating the Key Value Pairs"
    foreach($key in $NameValuePair.Keys){
        Write-Host "Key - $key"
        $temp = New-Object CCMSDKAPI.Name_Value_Pair
        $temp.Name = $key
        $temp.Value = $NameValuePair.$key
        $CCM_NameValuePair+=$temp
    }
    $sessionId =  New-Object System.Int32
    
    $ret = $initialize.CCMLaunchApplication($count,$CCM_NameValuePair,[ref]$sessionId);
    if($ret){
        Write-Host "Error launching Application from ICA File"
    }

}

<#
    .SYNOPSIS
        Gets the active session count i.e. The number of active session, and compares it against expected value
    .DESCRIPTION
        Gets the active session count i.e. The number of active session, and compares it against expected value
    .PARAMETER    
        ExpectedCount  - Expected no of session count
#>
function CCMGetActiveSessionCount{
    param(
        [parameter(Mandatory=$false)][int]$ExpectedCount
    )
    Write-Host "Getting the total number of active sessions"
    $count = New-Object System.Int64
    $ret =  $initialize.CCMGetActiveSessionCount([ref]$count)
    if($ret -ne 0){
        Write-Host "Active session count failed with error code $ret"
        throw "CCMGetActiveSessionCount Failed"
    }
    if($count -ne $ExpectedCount){
        write-host "Session  count is not as expected"
        write-host "ExpectedCount - $ExpectedCount"
        write-host "Actual -$count"
        throw "CCMGetActiveSessionCount Failed"
    }

}

<#
    .SYNOPSIS
        To get the reconnect setting of SR/ACR
    .DESCRIPTION
        To get the reconnect setting of SR/ACR
    .PARAMETER
        NonSeamlessAppTitle - Desktop/Application name as on Connection center
#>

function CCMGetReconnectSettings{
    param(
        [parameter(Mandatory=$true)][string]$NonSeamlessAppTitle
    )
    $ccmAppSession = CCMEnumerateSessions
    foreach($ccmSession in $ccmAppSession){
        if($ccmSession.NonSeamlessAppTitle -eq $NonSeamlessAppTitle){
            $SessionID = $ccmSession.SessionID
            Write-Host $SessionID
            $settings = New-Object CCMSDKAPI.CCM_WF_ReconnectSettingData
            $retVal = $initialize.CCMGetReconnectSettings($SessionID,[ref]$settings)
            Write-Host $retVal
            if($retVal -eq 0){
                return $settings
            }
            else{
                Write-Host "CCMGetReconnectSettings returned with $retVal"
                throw "CCMGetReconnectSettings failed"
            }
        }
    }
    Write-Host "No application/Desktop found with NonSeamlessAppTitle as title"
    throw "CCMGetReconnectSettings Failed"
}

<#
    .SYNOPSIS
        To verify the reconnect setting of SR/ACR
    .DESCRIPTION
        To verify the reconnect setting of SR/ACR
    .PARAMETER
        NonSeamlessAppTitle - Desktop/Application name as on Connection center
        SettingDetails - Hashtable consisting of settings
    .EXAMPLE
        VerifyCCMReconnectSetting -NonSeamlessAppTitle ${DesktopTitle} -SettingDetails @{'CGP_Title'=180;'UsAcrTimeout'=120}

        Hash table details are- 
        CGP_Title                                : 180
        CGP_WarnTime                             : 0
        CGPSessionReliabilityVersion             : 2
        CGPSessionReliabilityUIFlags             : 1
        CGPSessionReliabilityUIDimmingPercentage : 80
        UsAcrTimeout                             : 120
        UsACRUIFlags                             : 1
        UsACRUIDimmingPercentage                 : 80
        UsACREstimatedTCPTimeout                 : 60

#>

function VerifyCCMReconnectSetting{
    param(
        [parameter(Mandatory=$true)][string]$NonSeamlessAppTitle,
        [parameter(Mandatory=$true)][hashtable]$SettingDetails
    )
    Write-Host "Getting the session info"
    $settings = CCMGetReconnectSettings -NonSeamlessAppTitle $NonSeamlessAppTitle
    foreach($key in $SettingDetails.Keys){
        if($settings.$key -ne $SettingDetails.$key){
            Write-Host "Expected value of $key - "+ $SettingDetails.$key
            Write-Host "Observed value of $key - "+ $settings.$key
            throw "Reconnect Setting is not as expected"
        }
    }
    Write-Host "Reconnect setting details verified"
}


<#
    .SYNOPSIS
        To get the session id from session name
    .DESCRIPTION
        To get the session id from session name
    .PARAMETER
        SessionName - Desktop/Application name as on Connection center
#>
function GetSessionIdFromName{
    param(
        [parameter(Mandatory=$true)][String]$SessionName
    )
    $ccmSessionList = CCMEnumerateSessions
    foreach($obj in $ccmSessionList){
        if($obj.NonSeamlessAppTitle -eq $SessionName){
            $sessionId = $obj.SessionID
            break
        } 
    }
    return $sessionId
}

<#
    .SYNOPSIS
        To get the session attributes of Session
    .DESCRIPTION
        To get the session attributes of Session
    .PARAMETER
        SessionName - Desktop/Application name as on Connection center
#>
function CCMGetSessionAttributes{
    param(
        [parameter(Mandatory=$true)][String]$SessionName
    )
    $sessionId = GetSessionIdFromName -SessionName $SessionName
    $count = New-Object System.IntPtr
    $ppAttributes = @()
    $retVal =  $initialize.CCMGetSessionAttributes($sessionId,[ref]$ppAttributes);
    if($retVal -ne 0){
        Write-Host "CCMGetSessionAttributes failed with error code $retVal"
            throw "CCMGetSessionAttributes Failed"
    }
    return $ppAttributes
}


<#
    .SYNOPSIS
        To set the session attributes of Session
    .DESCRIPTION
        To set the session attributes of Session
    .PARAMETER
        SessionName - Desktop/Application name as on Connection center
        NameValPair - Hashtable consisting of Attribute Name and value
#>

function CCMSetSessionAttributes{
    param(
        [parameter(Mandatory=$true)][String]$SessionName,
        [parameter(Mandatory=$true)][hashtable]$NameValPair
    )
    $sessionId = GetSessionIdFromName -SessionName $SessionName
    $nameValPairArray = @()
    $NameValPair.Keys | % {  
    $ele = New-Object CCMSDKAPI.Name_Value_Pair
    $ele.Name = $_
    $ele.Value = $NameValPair[$_]
    $nameValPairArray += $ele
    }
    $nameValPairArray
    $retVal =  $initialize.CCMSetSessionAttributes($sessionId,$nameValPairArray.count,$nameValPairArray);
    if($retVal -ne 0){
        Write-Host "CCMSetSessionAttributes failed with error code $retVal"
            throw "CCMSetSessionAttributes Failed"
    }
}

<#
    .SYNOPSIS
        To delete the session attributes of Session
    .DESCRIPTION
        To delete the session attributes of Session
    .PARAMETER
        SessionName - Desktop/Application name as on Connection center
        NameValPair - Hashtable consisting of Attribute Name and value
#>

function CCMDeleteSessionAttribute{
    param(
        [parameter(Mandatory=$true)][String]$SessionName,
        [parameter(Mandatory=$true)][hashtable]$NameValPair
    )
    $sessionId = GetSessionIdFromName -SessionName $SessionName
    $obj = New-Object CCMSDKAPI.Name_Value_Pair
    $obj.Name = $NameValPair.Keys
    $obj.Value = $NameValPair[$NameValPair.Keys]
    $retVal =  $initialize.CCMDeleteSessionAttribute($sessionId,$obj);
    if($retVal -ne 0){
        Write-Host "CCMDeleteSessionAttribute failed with error code $retVal"
            throw "CCMDeleteSessionAttribute Failed"
    }

}

<#
    .SYNOPSIS
        Gets the list of all the Reverse Seamless Application session 
    .DESCRIPTION
        Gets the list of all the Reverse Seamless Application session 
    .PARAMETER    
#>
function CCMEnumerateRSApplications{
    Write-Host "Get the details of all the launched RS applications"
    $ccmRSIcaSessions = @()
    $retVal = $initialize.CCMEnumerateRSApplications([ref]$ccmRSIcaSessions)
    if($retVal){
        Write-Host "Failed Enumerating the RS sessions - $retVal"
        throw "CCMEnumerateRSApplications Failed"
    }
    Write-Host "Able to get Session details"
    $ccmRSIcaSessions
    return $ccmRSIcaSessions
}

<#
    .SYNOPSIS
        Verifies the RS Application details returned by CCMEnumerateRSApplications against array of Hashtable 
    .DESCRIPTION
        Verifies the RS Application details returned by CCMEnumerateRSApplications against array of Hashtable 
    .PARAMTER
        SessionDetails - HashTable
    .EXAMPLE
        VerifyCCMRSApplicationEnumeration -SessionDetails (@{'FriendlyName'='CMD'}

        Hash Table details

        ProcessID   SessionID FriendlyName
        ---------   --------- ------------
        6936 -1337443451 CMD         
        3008 -1337443451 conhost.exe 

#>
function VerifyCCMRSApplicationEnumeration{
    param(
        [parameter(Mandatory=$false)][hashtable[]]$SessionDetails
    )
    $count = 0
    $ccmIcaSessions = CCMEnumerateRSApplications
    Write-Host "Iterating the list of Hash Tables"
    foreach($hash in $SessionDetails){
        $res = IsHashSubSetOfObject -hash $hash -SessionDetails $ccmIcaSessions
        if($res){
            $count++
        }
    }
    if($count -eq $SessionDetails.count){
        Write-Host "CCM Enumeration function returned proper result" 
    }
    else{
        Write-Host "Failed Verifying the session details" 
        throw "CCMEnumerateRSApplications Verification Failed"
    }
}

<#
    .SYNOPSIS
        Terminates the required RS application
    .DESCRIPTION
        Terminates the required RS application
    .PARAMETER    
        ApplicationName
#>
function CCMTerminateRSApplication{
    param(
        [parameter(Mandatory=$true)][String]$ApplicationName
    )
    $proId = (Get-Process $ApplicationName | Select-Object Id).id | Select-Object -First 1 
    $retVal = $initialize.CCMTerminateRSApplication($proId)
    if($retVal){
        Write-Host "Error terminating the application"
        throw "CCMTerminateRSApplication Failed"
    }
    Write-Host "CCMTerminateRSApplication Successfull"
}

$source = "CCMCSharpModule.cs"
try
{
Add-Type -Path $source 
}
catch
{
    throw "Unable to load the C# file"
}
 
$initialize = CCMInitialize