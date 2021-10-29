function Get-PathSegment {
    @{
        "path" = @{
            "foregroundColor" = "Gray"
            "backgroundColor" = "Black"
            "expressions"     = @(
                @{
                    "expression" = '$executionContext.SessionState.Path.CurrentLocation'
                },
                @{
                    "expression" = '$Host.UI.RawUI.WindowTitle = if($title) {$title} else {$executionContext.SessionState.Path.CurrentLocation}'
                }
            )
            "newline"         = $true
        }
    }
}