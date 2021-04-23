[CmdletBinding()]
Param(

)

$modules = @(
    "Brasse.Powershell.Omnishell"
)

$settings = Get-Content -Path "$PSScriptRoot\settings.json" `
 | ConvertFrom-Json

$dependencies = $settings.modules

#Load Requirements
Write-Host "Loading Requirements..."
$dependencies | ForEach-Object {
    $isAvailable = Get-Module -ListAvailable -Name $_.Name `
    | Where-Object -Property Version -Value $_.Version -EQ
    if (!$isAvailable) {
        Install-Module $_.Name -RequiredVersion $_.Version
    }
    Import-Module $_.Name -RequiredVersion $_.Version
}

#Run Test
$modules | ForEach-Object {
    Write-Host "Running Tests for $_ ..."
    Invoke-Pester "$PSScriptRoot\src\$_\"
}

#Run Anylyzer
$modules | ForEach-Object {
    Write-Host "Anylyzing code fror $_ ..."
    Invoke-ScriptAnalyzer -Path "$PSScriptRoot\src\$_\" -Recurse
}
