function Get-PlatformSegment {
    @{
        "name"            = "platform"
        "expressions"     = @(
            @{
                "expression" = "switch([Environment]::OSVersion.Platform){ 'Win32NT'{''} 'Unix'{' '} 'MacOSX'{' '}}"
            }
        )
    }
}