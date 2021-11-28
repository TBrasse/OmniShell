function Get-AzContextSegment {
    @{
        "name"        = "azcontext"
        "expressions" = @(
            @{
                "expression" = "`$result = (Get-AzContext).Subscription.Name"
            },
            @{
                "expression" = "if(`$result){`" `$result`"}"
            }
        )
    }
}