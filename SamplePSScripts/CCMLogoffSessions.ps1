<#
    .SYNOPSIS
        Script to logoff all the sessions
    .DESCRIPION
        This script uses CCM SDK API to logoff all the running sessions on Client.
#>


Import-Module ..\CCMPowershellModule

CCMLogoffAllSessions
