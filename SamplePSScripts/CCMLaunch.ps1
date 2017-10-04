<#
    .SYNOPSIS
        Script to Launch Desktop/Application using ICA File
    .DESCRIPION
        This script uses CCMSDK API to Launch Application/Desktop. ICA File needs to be passed as arguments to it
#>
param(
    [parameter(Mandatory=$true)][string]$FilePath
)

Import-Module ..\CCMPowershellModule

CCMLaunchApplication -NameValuePair @{'ICA_FILE_PATH'="$FilePath"}