function Get-OmnishellCommand {
    param(
        [string] $Command,
        [string] $PerfixOnSuccess,
        [string] $OnFailure
    )
    $commandResult = Invoke-Expression $Command
    if ($commandResult) {
        $PerfixOnSuccess+$commandResult
    } else {
        $OnFailure
    }
}