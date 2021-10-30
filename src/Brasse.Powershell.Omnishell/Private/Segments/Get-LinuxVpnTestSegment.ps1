function Get-LinuxVpnTestSegment {
    @{
        "linuxVpnTest" = @{
            "prefix"          = ""
            "suffix"          = ""
            "foregroundColor" = "Black"
            "backgroundColor" = "DarkYellow"
            "expressions"     = @(
                @{
                    "expression" = '$result = -not ((host google.com) -match ".*not found.*")'
                },
                @{
                    "if" = '$result'
                },
                @{
                    "expression" = 'if($result) {" "} else {" "}'
                }
            )
        }
    }
}