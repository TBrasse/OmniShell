function Get-OmnishellPrompt {
    param(
        [string] $ConfigFile = $Global:Omnishell.Config
    )
    $Global:Omnishell.Segments = [System.Collections.ArrayList]::new()
    $consoleSize = $Host.UI.RawUI.WindowSize.Width
    $config = Get-Content $ConfigFile | ConvertFrom-Json -AsHashtable
    $profileName = (Invoke-Expression $config.switch -ErrorAction SilentlyContinue)
    $config.profiles[$profileName] | ForEach-Object {
        if (-not ($Global:Omnishell.Disabled."$($_.name)")) {
            $segement = Resolve-Segment -Segment $_
            $Global:Omnishell.Segments += $segement.Name
            if ($totalSize + $segement.Length -gt $consoleSize) {
                Write-OmnishellPrompt -NewLine $true
            }
            else {
                $totalSize += $segement.Length
            }
            $segement.Expressions | Write-OmnishellPrompt
            if ($null -ne $_.return) {
                Invoke-Expression $_.return
            }
        }
    }
}