param(
    [string] $NugetApiKey
)

if ([string]::IsNullOrEmpty($NugetApiKey)) {
    az account show 2>$null
    if($LASTEXITCODE -ne 0){
        az login
    }
    $rawKeyValue = az appconfig kv list -n "BrasseDevAppConfig" --key "PSGalleryNugetApiKey"
    $keyValue = $rawKeyValue | ConvertFrom-Json
    $NugetApiKey = $keyValue.Value
}

Publish-Module -Path  "$PSScriptRoot\build\Omnishell\" -NuGetApiKey $NugetApiKey