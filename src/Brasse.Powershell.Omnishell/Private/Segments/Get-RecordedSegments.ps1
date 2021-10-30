function Get-RecordedSegments {
    $recordedSegments = @{}
    $recordedSegments += Get-DateSegment
    $recordedSegments += Get-PlatformSegment
    $recordedSegments += Get-AzContextSegment
    $recordedSegments += Get-GitSegment
    $recordedSegments += Get-VpnTestSegment
    $recordedSegments += Get-LinuxVpnTestSegment
    $recordedSegments += Get-PathSegment
    $recordedSegments += Get-PromptSegment
    $recordedSegments += Get-NewlineSegment
    $recordedSegments
}