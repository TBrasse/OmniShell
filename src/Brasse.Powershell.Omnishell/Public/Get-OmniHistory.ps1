function Get-OmniHistory{
    param(
        [string] $Search
    )
    $content = Get-Content (Get-PSReadlineOption).HistorySavePath
    if($null -ne $Search){
        return $content | Select-String $Search
    }
    return $content
}