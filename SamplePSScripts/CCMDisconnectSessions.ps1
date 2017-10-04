<#
    .SYNOPSIS
        Script to disconnect all the sessions
    .DESCRIPION
        This script uses CCM SDK API to disconnect all the running sessions on Client.
#>


Import-Module ..\CCMPowershellModule

CCMDisconnectAllSessions

