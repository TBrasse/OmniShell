function Update-Config {
    param(
        [string] $Config = $Global:Omnishell.Config
    )

    $currentConfig = Get-Content -Path $Config | ConvertFrom-Json -AsHashtable
    $newConfig = Get-Content -Path "$PSScriptRoot\..\Brasse.Powershell.Omnishell.config.json" | ConvertFrom-Json -AsHashtable
    $currentVersion
    if ($null -ne $currentConfig.version) {
        $currentVersion = [System.Management.Automation.SemanticVersion]::New($currentConfig.version)
    }
    switch ($currentVersion) {
        $null {
            $newConfig.profiles = $currentConfig
            $newConfig | ConvertTo-Json -Depth 50 | Set-Content -Path $Config
            break
        }
        # {$currentVersion -lt "0.1.1"}{
        # update to future version
        # }
    }
}