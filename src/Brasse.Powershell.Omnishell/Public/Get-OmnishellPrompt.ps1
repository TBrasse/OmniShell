function Get-OmnishellPrompt {
    param(
        [string] $ConfigFile = $Global:Omnishell.Config
    )
    $consoleSize = $Host.UI.RawUI.WindowSize.Width
    $config = Get-Content $ConfigFile | ConvertFrom-Json -AsHashtable
    $profileName = (Invoke-Expression $config.switch -ErrorAction SilentlyContinue) ?? "default"
    $config.profiles[$profileName] | ForEach-Object {
        if (-not ($Global:Omnishell.Disabled."$($_.name)")) {
            $segement = Resolve-Expressions -Expressions $_.expressions
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