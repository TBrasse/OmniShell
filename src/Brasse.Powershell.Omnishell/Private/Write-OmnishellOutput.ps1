function Write-OmnishellOutput{
    param(
        [int] $Line = 0,
        [int] $Column = 0,
        [string] $String
    )
    $current = $host.UI.RawUI.CursorPosition
    $host.UI.RawUI.CursorPosition = [System.Management.Automation.Host.Coordinates]::new($Column,$Line)
    Write-Host $String
    $host.UI.RawUI.CursorPosition = $current
}