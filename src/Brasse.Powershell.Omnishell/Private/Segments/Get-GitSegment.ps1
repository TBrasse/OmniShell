function Get-GitSegment {
    @{
        "name"        = "git"
        "expressions" = @(
            @{
                "expression" = "`$result = Get-OmnishellGit"
            },
            @{
                "if" = "-not [string]::IsNullOrWhiteSpace(`$result)"
            },
            @{
                "expression" = "if(`$result) { `$title = Split-Path -LeafBase (git remote get-url origin) }"
            },
            @{
                "expression" = "if(`$result) { `" `$result`" }"
            }
        )
    }
}