function Get-AzContextSegment {
    @{
        "azcontext" = @{
            "prefix"          = ""
            "suffix"          = ""
            "foregroundColor" = "Black"
            "backgroundColor" = "DarkGray"
            "expressions"     = @(
                @{
                    "expression" = '$result = (Get-AzContext).Subscription.Name'
                },
                @{
                    "if" = '$null -ne $result'
                },
                @{
                    "expression" = "if(`$result){`" `$result`"} else {`" `"}"
                }
            )
        }
    }
}