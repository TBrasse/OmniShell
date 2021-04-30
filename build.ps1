[CmdletBinding()]
Param(
    [array] $BuildSteps
)

$modules = @(
    "Brasse.Powershell.Omnishell"
)

$settings = Get-Content -Path "$PSScriptRoot\settings.json" `
 | ConvertFrom-Json

#Load Requirements
Write-Host "Loading Requirements..."
$settings.modules | ForEach-Object {
    $isAvailable = Get-Module -ListAvailable -Name $_.Name `
    | Where-Object -Property Version -Value $_.Version -EQ
    if (!$isAvailable) {
        Install-Module $_.Name -RequiredVersion $_.Version
    }
    Import-Module $_.Name -RequiredVersion $_.Version
}

#Run Test
$modules | ForEach-Object {
    Get-ChildItem -Path "$PSScriptRoot\src\$_\Tests\*.ps1" | ForEach-Object {
        Write-Host "Running Tests for $($_.Name) ..."
        Invoke-Pester $_.FullName
    }
}

#Run Anylyzer
$modules | ForEach-Object {
    Write-Host "Anylyzing code for $_ ..."
    Invoke-ScriptAnalyzer -Path "$PSScriptRoot\src\$_\" -Recurse
}

function Import{
    $modules | ForEach-Object {
        Remove-Module "$_" -Force
        Import-Module "$PSScriptRoot\src\$_\$_.psm1"
        Write-Host "Imported module $_"
    }
}

#Run custom steps
foreach ($buildStep in $BuildSteps){
    &$buildStep
}