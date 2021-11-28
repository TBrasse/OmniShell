function Set-Segment {
    param(
        [hashtable] $Segment
    )
    $Global:Omnishell.Segments.($Segment.Name) = $Segment
}