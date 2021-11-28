function Get-DateSegment {
    @{
        "name"        = "date"
        "expressions" = @(
            @{
                "expression"      = "Get-Date -Format `"HH:mm:ss`""
                "foregroundColor" = "DarkGray"
            }
        )
    }
}