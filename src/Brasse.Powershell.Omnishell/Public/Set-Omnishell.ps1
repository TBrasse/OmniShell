$ConfigBegining = "## OmniShell Config Start"
$ConfigEnding = "## OmniShell Config End"
$Regex = "(?<ProfileBefore>(.|\n)*)?(?<Config>$ConfigBegining(.|\n)*$ConfigEnding)(?<ProfileAfter>(.|\n)*)?"

$Config="$ConfigBegining
    import-module $PSScriptRoot\..\Brasse.Powershell.Omnishell.psm1
$ConfigEnding
"

function Set-Omnishell {
    [CmdletBinding(SupportsShouldProcess)]
    Param(
        [switch] $Install,
        [string] $ConfigPath
    )

    if($Install){
        $profileContent = (Get-Content -Path $profile) -join [System.Environment]::NewLine
        if($profileContent -match $Regex){
            $newProfile = $Matches.ProfileBefore+$Config+$Matches.ProfileAfter
        }else{
            $newProfile = $profileContent+$Config
        }
        Set-Content -Path $profile -Value $newProfile
    }
    if($null -eq $Config){
        $Global:Omnishell.Config = $ConfigPath
    }
}