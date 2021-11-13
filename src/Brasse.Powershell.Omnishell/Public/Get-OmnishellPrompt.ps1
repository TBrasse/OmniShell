function Get-OmnishellPrompt {
    param(
        [string] $ConfigFile = $Global:Omnishell.Config
    )
    $consoleSize = $Host.UI.RawUI.WindowSize.Width
    $config = Get-Content $ConfigFile | ConvertFrom-Json -AsHashtable
    $profileName = (Invoke-Expression $config.switch -ErrorAction SilentlyContinue)

    $profile = $config.profiles[$profileName]
    $Global:Omnishell.loadedProfile = $profile

    $recordedSegments = Get-RecordedSegments
    $recordedSegments += Get-CustomSegments

    #ReadSegments
    foreach ($key in  $profile.segments.Keys) {
        $recordedSegments.$key = $profile.segments[$key]
    }
    #ResolveSegments
    $segments = foreach ($key in $profile.order) {
        Resolve-Segment -Segment $recordedSegments[$key] -Style ($profile.styles[$key])
    }

    #PrintSegments
    $segments | Write-Segment
}