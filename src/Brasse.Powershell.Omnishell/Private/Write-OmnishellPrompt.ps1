function Write-OmnishellPrompt {
    [CmdletBinding()]
    param(
        [Parameter(ValueFromPipelineByPropertyName)]
        [string] $Expression,
        [Parameter(ValueFromPipelineByPropertyName)]
        [string] $ForegroundColor,
        [Parameter(ValueFromPipelineByPropertyName)]
        [string] $BackgroundColor,
        [Parameter(ValueFromPipelineByPropertyName)]
        [bool] $NewLine
    )
    process {
        $param = @{
            Object = $Expression
        }
        if ($ForegroundColor) {
            $param.add( "ForegroundColor", $ForegroundColor )
        }
        if ($BackgroundColor) {
            $param.add( "BackgroundColor", $BackgroundColor )
        }
        if (-not $NewLine) {
            $param.add( "NoNewLine", !$NewLine )
        }
        Write-Host @param
    }
}