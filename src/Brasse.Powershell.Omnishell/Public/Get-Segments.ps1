function Get-Segments {
    $configFile = $Global:Omnishell.Config
    $config = Get-Content $configFile | ConvertFrom-Json -AsHashtable
    $profileName = Invoke-Expression $config.switch
    $config.profiles[$profileName] | ForEach-Object {
        $_.name
    }
}