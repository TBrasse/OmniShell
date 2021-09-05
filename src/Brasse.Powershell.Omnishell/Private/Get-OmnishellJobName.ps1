function Get-OmnishellJobName {
    param (
        [string] $SegmentName
    )
    "OmniShell_{0}_{1}" -f $PID, $SegmentName
}