function Write-Segment {
    param(
        [Parameter(ValueFromPipeline)]
        [PSCustomObject] $Segment
    )
    process {
        if ($Segment.format.prefix.Count -ne 0 -and $Segment.Format.segment.value.Length -gt 0) {
            [PSCustomObject] $Segment.format.prefix | Write-OmnishellPrompt
        }

        [PSCustomObject] $Segment.format.segment | Write-OmnishellPrompt

        if ($Segment.format.prefix.Count -ne 0 -and $Segment.Format.segment.value.Length -gt 0) {
            [PSCustomObject] $Segment.format.suffix | Write-OmnishellPrompt
        }

        if ($totalSize + $Segment.Length -gt $consoleSize) {
            Write-OmnishellPrompt -NewLine $true
        }
        else {
            $totalSize += $Segment.Length
        }
        # $Segment.Expressions | Write-OmnishellPrompt
        if ($null -ne $Segment.Prompt) {
            Invoke-Expression $Segment.Prompt
        }
    }
}