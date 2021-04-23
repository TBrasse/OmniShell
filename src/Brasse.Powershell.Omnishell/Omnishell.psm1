$public = Get-ChildItem -Path "$PSScriptRoot\Public\*.ps1"
$private = Get-ChildItem -Path "$PSScriptRoot\Private\*.ps1"

@($Public + $Private ) | ForEach-Object | Import-Module $_ -ErrorAction Ignore

Export-ModuleMember -Function $public.BaseName
