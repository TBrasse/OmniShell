function Get-OmnishellPrompt {
    param(
        [string] $ConfigFile = $Global:Omnishell.Config
    )
    $consoleSize = $Host.UI.RawUI.WindowSize.Width
    $config = Get-Content $ConfigFile | ConvertFrom-Json -AsHashtable
    $profileName = Invoke-Expression $config.switch
    $config.profiles[$profileName] | ForEach-Object {
        if (-not ($Global:Omnishell.Disabled."$($_.name)")) {
            try {
                $expressionSize = 0;
                [Array] $expressionsParams = foreach ($expression in $_.expressions) {
                    $prompt = (Invoke-Expression $expression.expression)
                    $expressionSize += $prompt.Length
                    [PSCustomObject] @{
                        BackgroundColor = $expression.backgroundColor
                        ForegroundColor = $expression.foregroundColor
                        Prompt          = $prompt
                        NewLine         = [bool]$expression.newline
                    }
                }
                if ($totalSize + $expressionSize -gt $consoleSize) {
                    Write-OmnishellPrompt -NewLine $true
                }
                else {
                    $totalSize += $expressionSize
                }
                $expressionsParams | Write-OmnishellPrompt
                if ($null -ne $_.return) {
                    Invoke-Expression $_.return
                }
            }
            catch {
                Write-Error "segment $($_.name) thrown error $_"
            }
        }
    }
}