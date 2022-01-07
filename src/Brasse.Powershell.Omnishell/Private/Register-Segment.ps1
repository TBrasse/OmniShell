function Register-Segment {
    param(
        [Parameter(Mandatory)]
        [string] $Name,
        [Parameter(Mandatory)]
        [scriptblock] $Segment
    )
    $result = Invoke-Command $Segment -ErrorAction Stop
    Test-CustomSegment $result
    $Global:Omnishell.CustomSegments.$Name = $result
}