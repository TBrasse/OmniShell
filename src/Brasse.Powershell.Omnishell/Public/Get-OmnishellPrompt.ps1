function Get-OmnishellPrompt {
    param(
        [Parameter(Mandatory)][string] $ConfigFile,
        [string] $ProfileName = "default"
    )
    $totalSize = 0
    $consoleSize = $Host.UI.RawUI.WindowSize.Width
    (Get-Content $ConfigFile | ConvertFrom-Json -AsHashtable)."$ProfileName" | ForEach-Object {
        $segmentName = $_.name
        try {
            $expressionSize = 0;
            $expressionsParams = foreach ($expression in $_.expressions) {
                $prompt = (Invoke-Expression $expression.expression)
                $expressionSize += $prompt.Length
                @{
                    BackgroundColor = $expression.backgroundColor
                    ForegroundColor = $expression.foregroundColor
                    Prompt          = $prompt
                    NewLine         = [bool]$expression.newline
                }
            }
            if($totalSize + $expressionSize -gt $consoleSize){
                Write-OmnishellPrompt -NewLine $true
            } else {
                $totalSize += $expressionSize
            }
            foreach($params in $expressionsParams){
                Write-OmnishellPrompt @params
            }
        }
        catch {
            Write-Error "segment $segmentName thrown error $_"
        }
    }
    "> "
}