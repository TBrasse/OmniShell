function Write-OmnishellPrompt {
    param(
        [string] $Prompt,
        [string] $ForegroundColor,
        [string] $BackgroundColor,
        [bool] $NewLine
    )
    $param = @{
        Object = $Prompt
    }
    if($ForegroundColor){
        $param.add( "ForegroundColor", $ForegroundColor )
    }
    if($BackgroundColor){
        $param.add( "BackgroundColor", $BackgroundColor )
    }
    if(-not $NewLine){
        $param.add( "NoNewLine", !$NewLine )
    }
    Write-Host @param
}