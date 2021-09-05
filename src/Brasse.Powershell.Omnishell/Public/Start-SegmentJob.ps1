function Start-SegmentJob {
    param(
        [Parameter(ValueFromPipeline)]
        [hashtable] $Segment
    )

    process {
        $parentPid = $PID
        $segmentName = $Segment.name
        $null = Start-Job -Name (Get-OmnishellJobName -SegmentName $segmentName) -ScriptBlock {
            param(
                [hashtable] $Segment,
                [string] $ModulePath,
                [string] $ParentPid
            )
            $segmentName = $Segment.name
            $segmentExpressions = $Segment.expressions
            import-module $ModulePath
            while ($true) {
                $segmentValue += foreach ($expression in $segmentExpressions) {
                    $prompt = (Invoke-Expression $expression.expression)
                    $prompt = if($null -ne $prompt){
                        $prompt.ToString()
                    }
                    $expressionSize += $prompt.Length
                    @{
                        BackgroundColor = $expression.backgroundColor
                        ForegroundColor = $expression.foregroundColor
                        Prompt          = $prompt
                        NewLine         = [bool]$expression.newline
                    }
                }
                Set-FileCash -CashName (Get-OmnishellCashName -ParentPid $ParentPid -SegmentName $segmentName) -CashValue $segmentValue
                $segmentValue = @()
                Start-Sleep -Milliseconds 500
            }
        } -ArgumentList $Segment, "$PSScriptRoot\..\Brasse.Powershell.Omnishell.psm1", $parentPid
    }
}