function Get-PathSegment {
    @{
        "path" = @{
            "foregroundColor" = "Gray"
            "expressions"     = @(
                @{
                    "expression" = '$executionContext.SessionState.Path.CurrentLocation'
                },
                @{
                    "expression" = '$Host.UI.RawUI.WindowTitle = if($title) {$title} else {$executionContext.SessionState.Path.CurrentLocation}'
                }
            )
        }
    }
}