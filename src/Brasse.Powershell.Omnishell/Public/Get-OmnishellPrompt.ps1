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
                if ($totalSize + $expressionSize -gt $consoleSize) {
                    Write-OmnishellPrompt -NewLine $true
                }
                else {
                    $totalSize += $expressionSize
                }
                foreach ($params in $expressionsParams) {
                    Write-OmnishellPrompt @params
                }
                if ($null -ne $_.return) {
                    $_.return
                }
            }
            catch {
                Write-Error "segment $($_.name) thrown error $_"
            }
        }
    }
}