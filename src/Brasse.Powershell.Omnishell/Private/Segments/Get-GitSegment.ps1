function Get-GitSegment {
    @{
        "git" = @{
            "prefix"          = ""
            "suffix"          = ""
            "foregroundColor" = "Black"
            "backgroundColor" = "DarkGreen"
            "expressions"     = @(
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
                    "expression" = "if(`$result) { `" `$result`" } else { `" `" }"
                }
            )
        }
    }
}