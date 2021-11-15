function Get-VpnTestSegment {
    @{
        "name"        = "vpnTest"
        "expressions" = @(
            @{
                "expression" = '$result = Resolve-DnsName google.com -Type A -DnsOnly -QuickTimeout -ErrorAction SilentlyContinue'
            },
            @{
                "expression" = 'if($result) {" "} else {" "}'
            }
        )
    }
}