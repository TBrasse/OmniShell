function Get-OmnishellPrompt {
    param(
        [string] $ConfigFile = $Global:Omnishell.Config
    )
    $Global:Omnishell.Segments = [System.Collections.ArrayList]::new()
    $consoleSize = $Host.UI.RawUI.WindowSize.Width
    $config = Get-Content $ConfigFile | ConvertFrom-Json -AsHashtable
    $profileName = (Invoke-Expression $config.switch -ErrorAction SilentlyContinue)

    $Global:Omnishell.loadedProfile = $config.profiles[$profileName]

    $recordedSegments = Get-RecordedSegments
    $recordedSegments += Get-CustomSegments
    foreach ($key in  $config.profiles[$profileName].segments.Keys) {
        $recordedSegments.$key = $config.profiles[$profileName].segments[$key]
    }
    $segments = foreach ($key in $config.profiles[$profileName].order) {
        Resolve-Segment -Segment $recordedSegments[$key]
    }

    $segments | ForEach-Object {
        if ($totalSize + $_.Length -gt $consoleSize) {
            Write-OmnishellPrompt -NewLine $true
        }
        else {
            $totalSize += $_.Length
        }
        $_.Expressions | Write-OmnishellPrompt
        if ($null -ne $_.Prompt) {
            Invoke-Expression $_.Prompt
        }
    }
}