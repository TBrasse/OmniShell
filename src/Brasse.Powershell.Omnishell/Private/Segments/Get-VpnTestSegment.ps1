function Get-VpnTestSegment {
    @{
        "vpnTest" = @{
            "prefix"          = ""
            "suffix"          = ""
            "foregroundColor" = "Black"
            "backgroundColor" = "DarkYellow"
            "expressions"     = @(
                @{
                    "expression" = '$result = Resolve-DnsName google.com -Type A -DnsOnly -QuickTimeout -ErrorAction SilentlyContinue'
                },
                @{
                    "if" = '$null -ne $result'
                },
                @{
                    "expression" = 'if($result) {" "} else {" "}'
                }
            )
            "newline"         = $true
        }
    }
}