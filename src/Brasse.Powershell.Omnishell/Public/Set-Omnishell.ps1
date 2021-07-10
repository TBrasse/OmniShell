$ConfigBegining = "## OmniShell Config Start"
$ConfigEnding = "## OmniShell Config End"
$Regex = "(?<ProfileBefore>(.|\n)*)?(?<Config>$ConfigBegining(.|\n)*$ConfigEnding)(?<ProfileAfter>(.|\n)*)?"

$Config="$ConfigBegining
    import-module D:\Workspace\Projects\OmniShell\src\Brasse.Powershell.Omnishell\Brasse.Powershell.Omnishell.psm1
    function prompt {
        Get-OmnishellPrompt -ConfigFile D:\Workspace\Projects\OmniShell\src\Brasse.Powershell.Omnishell\Brasse.Powershell.Omnishell.config.json
    }
$ConfigEnding
"

function Set-Omnishell {
    [CmdletBinding(SupportsShouldProcess)]
    Param(
        [switch] $Install
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
}