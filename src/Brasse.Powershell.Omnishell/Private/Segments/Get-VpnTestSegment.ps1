function Get-VpnTestSegment {
    @{
        "name"        = "vpnTest"
        "expressions" = @(
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
    }
}