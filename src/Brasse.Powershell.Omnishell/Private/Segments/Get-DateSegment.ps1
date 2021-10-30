function Get-DateSegment {
    @{
        "date" = @{
            "expressions" = @(
                @{
                    "expression"      = 'Get-Date -Format "HH:mm:ss"'
                    "foregroundColor" = "DarkGray"
                }
            )
        }
    }
}