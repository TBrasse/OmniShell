function Get-DateSegment {
    @{
        "date" = @{
            "expressions" = @(
                @{
                    "backgroundColor" = "Black"
                    "expression"      = 'Get-Date -Format "HH:mm:ss"'
                    "foregroundColor" = "DarkGray"
                }
            )
        }
    }
}