function Get-OmnishellPrompt {
    param(
        [Parameter(Mandatory)][string] $ConfigFile
    )
    (Get-Content $ConfigFile | ConvertFrom-Json).config | ForEach-Object {
        $params = @{
            Prompt = (&$_.Function)
            BackgroundColor = $_.BackgroundColor
            ForegroundColor = $_.ForegroundColor
            NoNewline = $_.NoNewline
        }
        Write-OmnishellPrompt @params
    }
}