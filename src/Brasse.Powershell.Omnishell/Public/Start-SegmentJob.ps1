function Start-SegmentJob {
    param(
        [Parameter(ValueFromPipeline)]
        [hashtable] $Segment
    )

    process {
        $segmentName = $Segment.name
        $null = Start-Job -Name "OmniShell_$segmentName" -ScriptBlock {
            param(
                [hashtable] $Segment,
                [string] $ModulePath
            )
            $segmentName = $Segment.name
            $segmentExpressions = $Segment.expressions
            import-module $ModulePath
            while ($true) {
                $segmentValue += foreach ($expression in $segmentExpressions) {
                    $prompt = (Invoke-Expression $expression.expression)
                    $expressionSize += $prompt.Length
                    @{
                        BackgroundColor = $expression.backgroundColor
                        ForegroundColor = $expression.foregroundColor
                        Prompt          = $prompt
                        NewLine         = [bool]$expression.newline
                    }
                }
                Set-FileCash -CashName $segmentName -CashValue $segmentValue
                Start-Sleep -Milliseconds 500
                $segmentValue = @()
            }
        } -ArgumentList $Segment, "$PSScriptRoot\..\Brasse.Powershell.Omnishell.psm1"
    }
}