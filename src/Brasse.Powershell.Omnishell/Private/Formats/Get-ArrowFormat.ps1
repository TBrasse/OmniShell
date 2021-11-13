function Get-ArrowStyle {
    param(
        [string] $Background,
        [string] $Foreground,
        [string] $Value
    )
    @{
        "prefix"  = @{ 
            "value"      = ""
            "background" = $Background
        }
        "segment" = @{
            "value"      = $Value
            "background" = $Background
            "foreground" = $Foreground
        }
        "suffix"  = @{
            "value"      = ""
            "foreground" = $Background
        }
    }
}