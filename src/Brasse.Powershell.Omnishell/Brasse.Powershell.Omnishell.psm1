$public = Get-ChildItem -Path "$PSScriptRoot\Public\*.ps1"
$private = Get-ChildItem -Path "$PSScriptRoot\Private\*.ps1"

@($public + $private ) | ForEach-Object {
    Import-Module $_.FullName
}

Export-ModuleMember -Function $public.BaseName
