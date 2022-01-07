function Get-OmnishellLine{
    param(
        $Line
    )
    $MaxCharacters = $Host.UI.RawUI.WindowSize.Width-1
    $buffer = $Host.UI.RawUI.GetBufferContents([System.Management.Automation.Host.Rectangle]::new(0,$Line,$MaxCharacters,$Line))
    ($buffer.Character -join "").TrimEnd()
}