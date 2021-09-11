function Disable-Segment {
    param(
        [string] $Name
    )
    $Global:Omnishell.Disabled."$Name" = $true
}