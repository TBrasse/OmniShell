function Get-OmnishellPrompt {
    param(
        [Parameter(Mandatory)][string] $ConfigFile
    )
    $PreviousBackgroudColor = (get-host).ui.rawui.BackgroundColor
    (Get-Content $ConfigFile | ConvertFrom-Json).config | ForEach-Object {
        #Hyphen
        $params = @{
            Prompt          = ($_.Hyphen)
            BackgroundColor = $_.BackgroundColor
            ForegroundColor = $PreviousBackgroudColor
            NoNewline       = $true
        }
        Write-OmnishellPrompt @params
        $params = @{
            Prompt          = ($_.Prefix) + (&($_.Function) $_.Param)
            BackgroundColor = $_.BackgroundColor
            ForegroundColor = $_.ForegroundColor
            NoNewline       = $true
        }
        Write-OmnishellPrompt @params
        if (-not $_.NoNewline) {
            $params = @{
                Prompt    = ""
                NoNewline = $false
            }
            Write-OmnishellPrompt @params
            $PreviousBackgroudColor = (get-host).ui.rawui.BackgroundColor
        }
        else {
            $PreviousBackgroudColor = $_.BackgroundColor
        }
    }
}