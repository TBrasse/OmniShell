function Get-AzContextSegment {
    @{
        "name"        = "azcontext"
        "expressions" = @(
            @{
                "expression" = '$result = (Get-AzContext).Subscription.Name'
            },
            @{
                "if" = '$null -ne $result'
            },
            @{
                "expression" = 'if($result){\" $result\"} else {" "}'
            }
        )
    }
}