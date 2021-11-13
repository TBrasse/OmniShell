function Get-ClearStyle {
    param(
        [string] $Background,
        [string] $Foreground,
        [string] $Value
    )
    @{
        "prefix"  = @{}
        "segment" = @{
            "value"      = $Value
            "foreground" = $Foreground
        }
        "suffix"  = @{}
    }
}