function Format-Segments {
    param(
        [Array] $Segments,
        [hashtable] $Styles
    )
    foreach($segment in $Segments){
        $style = $Styles[$segment.Name]
        $format = Get-Format @Style -Value $segment.Expression
        $segment | Add-Member -Name "Format" -Value $format -MemberType NoteProperty
        $segment.Length += $format.prefix.Length + $format.segment.Lenght
        $segment
    }
}