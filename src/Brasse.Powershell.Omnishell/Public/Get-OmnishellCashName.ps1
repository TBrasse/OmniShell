function Get-OmnishellCashName {
    param (
        [string] $ParentPid,
        [string] $SegmentName
    )
    $sessionPid = $ParentPid
    if($null -eq $sessionPid){
        $sessionPid = $PID
    }
    "{0}_{1}" -f $sessionPid, $SegmentName
}