function Get-OmnishellPrompt {
    param(
        [string] $ConfigFile = $Global:Omnishell.Config
    )
    $consoleSize = $Host.UI.RawUI.WindowSize.Width
    $config = Get-Content $ConfigFile | ConvertFrom-Json -AsHashtable
    $profileName = (Invoke-Expression $config.switch -ErrorAction SilentlyContinue)

    $configProfile = $config.profiles[$profileName]
    $Global:Omnishell.loadedProfile = $configProfile

    $recordedSegments = Get-RecordedSegments
    $recordedSegments += Get-CustomSegments

    #ReadSegments
    foreach ($key in  $configProfile.segments.Keys) {
        $recordedSegments.$key = $configProfile.segments[$key]
    }
    #ResolveSegments
    $segments = foreach ($key in $configProfile.order) {
        Resolve-Segment -Segment $recordedSegments[$key]
    }

    $formatedSegments = Format-Segments -Segments $segments -Styles $configProfile.styles

    #PrintSegments
    $formatedSegments | Write-Segment
}