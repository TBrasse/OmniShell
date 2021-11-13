function Get-LinuxVpnTestSegment {
    @{
        "name"        = "linuxVpnTest"
        "expressions" = @(
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