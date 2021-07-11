function Uninstall-Omnishell {
    $profileConfig = Get-ProfileConfig
    $profileContent = (Get-Content -Path $profile) -join [System.Environment]::NewLine
    if ($profileContent -match $profileConfig.Regex) {
        $newProfile = $Matches.ProfileBefore + $Matches.ProfileAfter
    }
    Set-Content -Path $profile -Value $newProfile
}