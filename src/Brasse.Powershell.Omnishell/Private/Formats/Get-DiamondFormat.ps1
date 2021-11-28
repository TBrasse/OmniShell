function Get-DiamondStyle {
    param(
        [string] $Background,
        [string] $Foreground,
        [string] $Value
    )
    @{
        "prefix"  = @{ 
            "value"      = ""
            "foreground" = $Background 
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