function Get-ProfileConfig {
    $ConfigBegining = "## OmniShell Config Start"
    $ConfigEnding = "## OmniShell Config End"
    $Regex = "(?<ProfileBefore>(.|\n)*)?(?<Config>$ConfigBegining(.|\n)*$ConfigEnding)(?<ProfileAfter>(.|\n)*)?"

$Config = "$ConfigBegining
import-module $PSScriptRoot\..\Brasse.Powershell.Omnishell.psm1
$ConfigEnding"
    @{
        "Config" = $Config
        "Regex" = $Regex
    }
}