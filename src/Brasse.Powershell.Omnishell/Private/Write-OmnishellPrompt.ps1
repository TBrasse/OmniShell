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
        if (-not [string]::IsNullOrWhiteSpace($ForegroundColor)) {
            $param.add( "ForegroundColor", $ForegroundColor )
        }
        if (-not [string]::IsNullOrWhiteSpace($BackgroundColor)) {
            $param.add( "BackgroundColor", $BackgroundColor )
        }
        if (-not $NewLine) {
            $param.add( "NoNewLine", !$NewLine )
        }
        Write-Host @param
    }
}