if($null -eq $Global:Omnishell){
    $Global:Omnishell = @{}
}
if($null -eq $Global:Omnishell.AppDir){
    $Global:Omnishell.AppDir = "$env:APPDATA\Omnishell"
}
if($null -eq $Global:Omnishell.Config){
    $Global:Omnishell.Config = "$($Global:Omnishell.AppDir)\config.json"
}

$public = Get-ChildItem -Path "$PSScriptRoot\Public\*.ps1"
$private = Get-ChildItem -Path "$PSScriptRoot\Private\*.ps1"

@($public + $private ) | ForEach-Object {
    Import-Module $_.FullName
}

if(-not (Test-Path -Path $Global:Omnishell.Config)){
    Copy-Item -Path "$PSScriptRoot\Brasse.Powershell.Omnishell.config.json" -Destination $Global:Omnishell.Config
} else {
    Update-Config
}

function prompt {
    Get-OmnishellPrompt -ConfigFile $Global:Omnishell.Config
}

Export-ModuleMember -Function $public.BaseName
Export-ModuleMember -Function prompt
