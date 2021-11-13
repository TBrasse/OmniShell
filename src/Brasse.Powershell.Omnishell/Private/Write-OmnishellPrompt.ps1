function Write-OmnishellPrompt {
    [CmdletBinding()]
    param(
        [Parameter(ValueFromPipelineByPropertyName)]
        [string] $Value,
        [Parameter(ValueFromPipelineByPropertyName)]
        [string] $Foreground,
        [Parameter(ValueFromPipelineByPropertyName)]
        [string] $Background
    )
    process {
        $param = @{
            Object = $Value
        }
        if (-not [string]::IsNullOrWhiteSpace($Foreground)) {
            $param.add( "Foreground", $Foreground )
        }
        if (-not [string]::IsNullOrWhiteSpace($Background)) {
            $param.add( "Background", $Background )
        }
        Write-Host @param -NoNewline
    }
}