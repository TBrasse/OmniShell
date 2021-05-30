function Get-OmnishellSeverConnection {
    param(
        [string] $Server,
        [string] $OnConnected,
        [string] $OnDiscconnected
    )

    $result = Test-Connection -TargetName $Server -ResolveDestination -Count 1 -ErrorAction SilentlyContinue
    if($result -and $result.Status -eq "Success"){
        $OnConnected
    } else {
        $OnDiscconnected
    }
}