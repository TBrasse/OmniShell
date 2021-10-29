$AppData = switch ([Environment]::OSVersion.Platform) {
    'Win32NT' { $env:APPDATA } 
    'Unix' {
        $path = "$env:HOME"
        if (-not (Test-Path -Path $path)) {
            New-Item -Path $path -ItemType Directory
        }
        $path
    }
}
if ($null -eq $Global:Omnishell) {
    $Global:Omnishell = @{}
}
if ($null -eq $Global:Omnishell.AppDir) {
    $Global:Omnishell.AppDir = Join-Path $AppData "Omnishell"
}
if ($null -eq $Global:Omnishell.Config) {
    $Global:Omnishell.Config = Join-Path $Global:Omnishell.AppDir "config.json"
}
if ($null -eq $Global:Omnishell.Disabled){
    $Global:Omnishell.Disabled = @{}
}
if ($null -eq $Global:Omnishell.Segments){
    $Global:Omnishell.Segments = @()
}
if(-not (Test-Path -Path $Global:Omnishell.AppDir)){
    New-Item -Path $Global:Omnishell.AppDir -ItemType Directory
}
$public = Get-ChildItem -Path (Join-Path $PSScriptRoot "Public" "*.ps1")
$private = Get-ChildItem -Path (Join-Path $PSScriptRoot "Private" "*.ps1")

@($public + $private ) | ForEach-Object {
    Import-Module $_.FullName
}

if (-not (Test-Path -Path $Global:Omnishell.Config)) {
    Copy-Item -Path (Join-Path $PSScriptRoot "Brasse.Powershell.Omnishell.config.json") -Destination $Global:Omnishell.Config -Force
}
else {
    Update-Config
}

function prompt {
    Get-OmnishellPrompt -ConfigFile $Global:Omnishell.Config
}

Export-ModuleMember -Function $public.BaseName
Export-ModuleMember -Function prompt
