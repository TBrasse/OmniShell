function Get-OmnishellPrompt {
    param(
        [Parameter(Mandatory)][string] $ConfigFile
    )
    $PreviousBackgroudColor = (get-host).ui.rawui.BackgroundColor
    (Get-Content $ConfigFile | ConvertFrom-Json).config | ForEach-Object {
        #Hyphen
        $params = @{
            BackgroundColor = $_.BackgroundColor
            ForegroundColor = $_.ForegroundColor
            NoNewline       = $true
        }
        Write-OmnishellPrompt @params -Prompt ($_.Hyphen) -ForegroundColor $PreviousBackgroudColor
        $commandResult = Invoke-Expression $_.Function
        $commandMessage = if ($commandResult) {
            if($_.OnSuccess){
                $_.OnSuccess
            }else{
                $_.PerfixOnSuccess+$commandResult
            }
        } else {
            $_.OnFailure
        }
        Write-OmnishellPrompt @params -Prompt $commandMessage
        if ($_.Newline) {
            $params = @{
                Prompt    = ""
                NoNewline = !$_.Newline
            }
            Write-OmnishellPrompt @params
            $PreviousBackgroudColor = (get-host).ui.rawui.BackgroundColor
        }
        else {
            $PreviousBackgroudColor = $_.BackgroundColor
        }
    }
    " > "
}