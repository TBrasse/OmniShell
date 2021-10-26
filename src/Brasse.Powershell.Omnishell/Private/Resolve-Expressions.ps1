function Resolve-Expressions {
    param(
        [Array] $Expressions
    )
    $expressionSize = 0;
    try {
        [Array] $resolved = foreach ($expression in $Expressions) {
            $prompt = (Invoke-Expression $expression.expression)
            $expressionSize += $prompt.Length
            [PSCustomObject] @{
                BackgroundColor = $expression.backgroundColor
                ForegroundColor = $expression.foregroundColor
                Prompt          = $prompt
                NewLine         = [bool]$expression.newline
            }
        }
    }
    catch {
        Write-Error "segment $($_.name) thrown error $_"
    }
    @{
        "Length"      = $expressionSize
        "Expressions" = $resolved
    }
}