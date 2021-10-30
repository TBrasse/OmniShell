function Get-PlatformSegment {
    @{
        "platform" = @{
            "prefix"          = ""
            "suffix"          = ""
            "foregroundColor" = "Black"
            "backgroundColor" = "Blue"
            "expressions"     = @(
                @{
                    "expression" = "switch([Environment]::OSVersion.Platform){ 'Win32NT'{''} 'Unix'{' '} 'MacOSX'{' '}}"
                }
            )
        }
    }
}