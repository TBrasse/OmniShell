function Get-LinuxVpnTestSegment {
    @{
        "name"        = "linuxVpnTest"
        "expressions" = @(
            @{
                "expression" = "`$result = -not ((host google.com) -match `".*not found.*`")"
            },
            @{
                "expression" = "if(`$result) {`" `"} else {`" `"}"
            }
        )
    }
}