function Update-Config {
    param(
        [string] $Config = $Global:Omnishell.Config
    )

    $currentConfig = Get-Content -Path $Config | ConvertFrom-Json -AsHashtable
    if ($null -ne $currentConfig.version) {
        $currentVersion = [System.Management.Automation.SemanticVersion]::New($currentConfig.version)
    }
    switch ($currentVersion) {
        $null {
            $newConfig = Get-Content -Path "$PSScriptRoot\..\Brasse.Powershell.Omnishell.config.json" | ConvertFrom-Json -AsHashtable
            $newConfig.profiles = $currentConfig
            $newConfig | ConvertTo-Json -Depth 50 | Set-Content -Path $Config
            break
        }
        { $currentVersion -lt "0.2.0" } {
            $newConfig = $currentConfig
            $newConfig.version = "0.2.0"
            foreach ($profileName in $currentConfig.profiles.Keys) {
                $newConfig.profiles.$profileName += @{
                    name   = "prompt"
                    return = "> "
                }
            }
            $newConfig | ConvertTo-Json -Depth 50 | Set-Content -Path $Config
        }
        # {$currentVersion -lt "0.1.1"}{
        # update to future version
        # }
    }
}