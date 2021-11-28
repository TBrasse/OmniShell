function Get-RibbonFormat {
    param(
        [hashtable] $PreviousStyle,
        [Parameter(Mandatory)]
        [hashtable] $CurrentStyle,
        [hashtable] $NextStyle,
        [string] $Value
    )
    @{
        "prefix"  = @{ 
            "value"      = if($PreviousStyle.format -eq "ribbon" ) {""} else {""} 
            "foreground" = $CurrentStyle.background
        }
        "segment" = @{
            "value"      = " $Value "
            "background" = $CurrentStyle.background
            "foreground" = $CurrentStyle.foreground
        }
        "suffix"  = @{
            "value"      = "" 
            "background" = $NextStyle.background
            "foreground" = $CurrentStyle.background
        }
    }
}