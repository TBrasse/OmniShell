function Get-OmnishellPrompt {
    param(
        [Parameter(Mandatory)][string] $ConfigFile,
        [string] $ProfileName = "default"
    )
    (Get-Content $ConfigFile | ConvertFrom-Json -AsHashtable)."$ProfileName" | ForEach-Object {
        $segmentName = $_.name
        try {
            foreach ($expression in $_.expressions) {
                $prompt = (Invoke-Expression $expression.expression)
                $params = @{
                    BackgroundColor = $expression.backgroundColor
                    ForegroundColor = $expression.foregroundColor
                    Prompt          = $prompt
                    NewLine         = [bool]$expression.newline
                }
                Write-OmnishellPrompt @params
            }
        }
        catch {
            Write-Error "segment $segmentName thrown error $_"
        }
    }
    "> "
}