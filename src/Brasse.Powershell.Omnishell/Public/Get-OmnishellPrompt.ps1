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
        $command = $_.Function
        if($_.Params){
            $commandParams = $_.Params
            $commandParamValues = ((Get-Member -InputObject $commandParams -MemberType Properties).Name | ForEach-Object { "-$_ `"$($commandParams.$_)`" "}) -join ""
            $command += " $commandParamValues"
        }
        $commnadResult = Invoke-Expression $command
        Write-OmnishellPrompt @params -Prompt "$($_.Prefix)$commnadResult"
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