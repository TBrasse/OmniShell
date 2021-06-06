function Get-OmnishellPrompt {
    param(
        [Parameter(Mandatory)][string] $ConfigFile
    )
    (Get-Content $ConfigFile | ConvertFrom-Json).config | ForEach-Object {
        #Hyphen
        $hyphenParams = @{
            BackgroundColor = $_.Hyphen.BackgroundColor
            ForegroundColor = $_.Hyphen.ForegroundColor
            Prompt = $_.Hyphen.Prefix
            Newline       = $false
        }
        Write-OmnishellPrompt @hyphenParams
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
        $params = @{
            BackgroundColor = $_.BackgroundColor
            ForegroundColor = $_.ForegroundColor
            Prompt = $commandMessage
            Newline       = $false
        }
        Write-OmnishellPrompt @params

        $hyphenParams = @{
            BackgroundColor = $_.Hyphen.BackgroundColor
            ForegroundColor = $_.Hyphen.ForegroundColor
            Prompt = $_.Hyphen.Suffix
            Newline       = $false
        }
        Write-OmnishellPrompt @hyphenParams

        if ($_.Newline) {
            Write-OmnishellPrompt -Prompt "" -Newline $true
        }
    }
    "> "
}