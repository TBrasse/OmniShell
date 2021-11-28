function Format-Segments {
    param(
        [Array] $Segments,
        [hashtable] $Styles
    )
    for($index =0; $index -lt $Segments.Count; $index++){
        $segment = $Segments[$index]
        # $style = $Styles[$segment.Name]
        $previousStyle = if( $index -lt $Segments.Count +1 ) {
            $Styles[$Segments[$index-1].Name]
        }
        $currentStyle = $Styles[$Segments[$index].Name]
        $nextStyle = if( $index -lt $Segments.Count -1 ) {
            $Styles[$Segments[$index+1].Name]
        }
        $format = Get-Format -PreviousStyle $previousStyle -CurrentStyle $currentStyle -NextStyle $nextStyle -Value $segment.Expression
        $segment | Add-Member -Name "Format" -Value $format -MemberType NoteProperty
        $segment.Length += $format.prefix.Length + $format.segment.Lenght
        $segment
    }
}