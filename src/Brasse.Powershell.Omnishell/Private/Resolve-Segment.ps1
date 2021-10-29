function Resolve-Segment {
    param(
        [hashtable] $Segment
    )
    try {
        $expressionSize = 0;
        $resolved = [System.Collections.ArrayList]::new();
        $resolved += [PSCustomObject] @{
            BackgroundColor = $Segment.foregroundColor
            ForegroundColor = $Segment.backgroundColor
            Prompt          = $Segment.prefix
        }
        $expressionSize += $Segment.prefix.length
        foreach ($expression in $Segment.expressions) {
            switch ($expression) {
                { $_.expression } {
                    $prompt = (Invoke-Expression $expression.expression)
                    $expressionSize += $prompt.Length
                    $resolved += [PSCustomObject] @{
                        BackgroundColor = $expression.backgroundColor ?? $Segment.backgroundColor
                        ForegroundColor = $expression.foregroundColor ?? $Segment.foregroundColor
                        Prompt          = $prompt
                        NewLine         = [bool]$expression.newline
                    }
                }
                { $_.if } {
                    if ($false -eq (Invoke-Expression $expression.if)) {
                        return @{}
                    }
                }
            }
        }
        $resolved += [PSCustomObject] @{
            BackgroundColor = $Segment.foregroundColor
            ForegroundColor = $Segment.backgroundColor
            Prompt          = $Segment.suffix
            NewLine         = ($Segment.newline ?? $false)
        }
        $expressionSize += $Segment.suffix.length
    }
    catch {
        Write-Error "segment $($_.name) thrown error $_"
    }
    @{
        "Name"        = $Segment.name
        "Length"      = $expressionSize
        "Expressions" = $resolved
    }
}