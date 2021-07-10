function Start-SegmentJob{
    param(
        [hashtable] $Segment
    )

    $null = Start-Job -Name $Segment.name -ScriptBlock {
        param(
            [hashtable] $Segment
        )
        $segmentParams = foreach ($expression in $Segment.expressions) {
            $prompt = (Invoke-Expression $expression.expression)
            $expressionSize += $prompt.Length
            @{
                BackgroundColor = $expression.backgroundColor
                ForegroundColor = $expression.foregroundColor
                Prompt          = $prompt
                NewLine         = [bool]$expression.newline
            }
        }
        Set-FileCash -CashName $Segment.Name -NewCash $segmentParams
    } -InitializationScript {
        import-module D:\Workspace\Projects\OmniShell\src\Brasse.Powershell.Omnishell\Brasse.Powershell.Omnishell.psm1
    } -ArgumentList $_
}