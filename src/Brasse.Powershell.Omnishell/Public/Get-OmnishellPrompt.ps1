function Get-OmnishellPrompt {
    param(
        [string] $ConfigFile = $Global:Omnishell.Config
    )
    $totalSize = 0
    $consoleSize = $Host.UI.RawUI.WindowSize.Width
    $config = Get-Content $ConfigFile | ConvertFrom-Json -AsHashtable
    $profileName = Invoke-Expression $config.switch
    $config.profiles[$profileName] | ForEach-Object {
        $expressionSize = 0;
        $segmentName = $_.name
        # Start-SegmentJob -Segment $_
        # $segmentResult = Get-FileCash -CashName $_.name

        # $expressionSize += $segmentResult.Prompt.Length
        # if($totalSize + $expressionSize -gt $consoleSize){
        #     Write-OmnishellPrompt -NewLine $true
        # } else {
        #     $totalSize += $expressionSize
        # }

        # foreach($segementParams in $segmentResult){
        #     Write-OmnishellPrompt @segementParams
        # }
        try {
            $segmentJob = Get-Job -Name (Get-OmnishellJobName -SegmentName $segmentName)
            if($null -eq $segmentJob) {
                Start-SegmentJob -Segment $_
            }else{
                $segementExpressions = Get-FileCash -CashName (Get-OmnishellCashName -ParentPid $PID -SegmentName $segmentName)
            }
            # $segementExpressions = foreach ($expression in $_.expressions) {
            #     $prompt = (Invoke-Expression $expression.expression)
            #     $expressionSize += $prompt.Length
            #     @{
            #         BackgroundColor = $expression.backgroundColor
            #         ForegroundColor = $expression.foregroundColor
            #         Prompt          = $prompt
            #         NewLine         = [bool]$expression.newline
            #     }
            # }
            if($totalSize + $expressionSize -gt $consoleSize){
                Write-OmnishellPrompt -NewLine $true
            } else {
                $totalSize += $expressionSize
            }
            foreach($params in $segementExpressions){
                Write-OmnishellPrompt @params
            }
        }
        catch {
            Write-Error "segment $segmentName thrown error $_"
        }
    }
    "> "
}