function Install-Omnishell {
    [CmdletBinding(SupportsShouldProcess)]
    Param(
        [string] $ConfigFile
    )

    $profileDirectory = (Get-Item $profile).Directory.FullName
    $configName = (Get-Item $ConfigFile).Name
    $moduleRepository = ($env:PSModulePath -split ';')[0]
    $value = `
    "Import-Module Omnishell
    function prompt {
        Get-Prompt $profileDirectory\$configName
    }"
    if($PSCmdlet.ShouldProcess('$profile',"adding Omnisharp prompt")){
        Copy-Item -Path $ConfigFile -Destination $profileDirectory
        Add-Content `
            -Path $profile `
            -Value $value `
            -WhatIf:$WhatIfPreference
    }
}