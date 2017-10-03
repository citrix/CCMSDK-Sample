<#
    .SYNOPSIS
        Script to Enumerate all the sessions that are running
    .DESCRIPION
        This script uses CCM SDK API to get the details of all the running sessions on Client.
#>


Import-Module ..\CCMPowershellModule

CCMEnumerateSessions
