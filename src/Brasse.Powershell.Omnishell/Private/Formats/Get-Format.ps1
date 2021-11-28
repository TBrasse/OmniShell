function Get-Format {
    param(
        [Parameter(Mandatory)]
        [hashtable] $PreviousStyle,
        [hashtable] $CurrentStyle,
        [hashtable] $NextStyle,
        [string] $Value
    )
    switch ($CurrentStyle.format) {
        "Arrow" { Get-ArrowStyle -Background $CurrentStyle.background -Foreground $CurrentStyle.foreground -Value $Value }
        "Diamond" { Get-DiamondStyle -Background $CurrentStyle.background -Foreground $CurrentStyle.foreground -Value $Value }
        "Ribbon" { 
            @{
                "prefix"  = @{ 
                    "value"      = if($PreviousStyle.format -eq "ribbon" ) {""} else {""} 
                    "foreground" = $CurrentStyle.background
                }
                "segment" = @{
                    "value"      = $Value
                    "background" = $CurrentStyle.background
                    "foreground" = $CurrentStyle.foreground
                }
                "suffix"  = @{
                    "value"      = " " 
                    "background" = $NextStyle.background
                    "foreground" = $CurrentStyle.background
                }
            }
        }
        "Clear" { Get-ClearStyle -Background $CurrentStyle.background -Foreground $CurrentStyle.foreground -Value $Value }
        Default { Get-ClearStyle -Background $CurrentStyle.background -Foreground $CurrentStyle.foreground -Value $Value }
    }
}