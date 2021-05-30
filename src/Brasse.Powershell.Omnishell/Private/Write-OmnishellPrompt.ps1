function Write-OmnishellPrompt {
    param(
        [string] $Prompt,
        [string] $ForegroundColor,
        [string] $BackgroundColor,
        [bool] $NoNewLine
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
    if($NoNewLine){
        $param.add( "NoNewLine", $NoNewLine )
    }
    Write-Host @param
}