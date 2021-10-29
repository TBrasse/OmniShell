function Resolve-Segment {
    param(
        [hashtable] $Segment
    )
    try {
        $expressionSize = 0;
        $resolved = [System.Collections.ArrayList]::new();
        if ($Segment.prefix) {
            $resolved += [PSCustomObject] @{
                BackgroundColor = $Segment.foregroundColor
                ForegroundColor = $Segment.backgroundColor
                Expression      = $Segment.prefix
            }
            $expressionSize += $Segment.prefix.length
        }
        foreach ($expression in $Segment.expressions) {
            switch ($expression) {
                { $_.expression } {
                    $resolvedExpression = (Invoke-Expression $expression.expression)
                    $expressionSize += $resolvedExpression.Length
                    $resolved += [PSCustomObject] @{
                        BackgroundColor = $expression.backgroundColor ?? $Segment.backgroundColor
                        ForegroundColor = $expression.foregroundColor ?? $Segment.foregroundColor
                        Expression      = $resolvedExpression
                        NewLine         = [bool]($expression.newline ?? $false)
                    }
                    break
                }
                { $_.if } {
                    if ($false -eq (Invoke-Expression $expression.if)) {
                        return @{}
                    }
                    break
                }
            }
        }
        $resolved += [PSCustomObject] @{
            BackgroundColor = $Segment.foregroundColor
            ForegroundColor = $Segment.backgroundColor
            Expression      = $Segment.suffix
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
        "Prompt"      = $Segment.prompt
    }
}