function Install-Omnishell {
    Param(
        [string] $ConfigPath
    )

    $profileConfig = Get-ProfileConfig
    $profileContent = (Get-Content -Path $profile) -join [System.Environment]::NewLine
    if ($profileContent -match $profileConfig.Regex) {
        $newProfile = $Matches.ProfileBefore + $profileConfig.Config + $Matches.ProfileAfter
    }
    else {
        $newProfile = $profileContent + $profileConfig.Config
    }
    Set-Content -Path $profile -Value $newProfile
    if ($null -ne $ConfigPath) {
        $Global:Omnishell.Config = $ConfigPath
    }
}