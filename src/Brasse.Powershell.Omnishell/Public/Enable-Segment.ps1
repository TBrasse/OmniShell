function Enable-Segment {
    param(
        [string] $Name,
        [switch] $All
    )
    if ($All) {
        $Global:Omnishell.Disabled = @{}
    }
    else {
        $Global:Omnishell.Disabled."$Name" = $false
    }
}