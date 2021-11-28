function Get-Format {
    param(
        [hashtable] $PreviousStyle,
        [Parameter(Mandatory)]
        [hashtable] $CurrentStyle,
        [hashtable] $NextStyle,
        [string] $Value
    )
    switch ($CurrentStyle.format) {
        "Arrow" { Get-ArrowStyle -Background $CurrentStyle.background -Foreground $CurrentStyle.foreground -Value $Value }
        "Diamond" { Get-DiamondStyle -Background $CurrentStyle.background -Foreground $CurrentStyle.foreground -Value $Value }
        "Ribbon" { Get-RibbonFormat -PreviousStyle $PreviousStyle -CurrentStyle $CurrentStyle -NextStyle $NextStyle -Value $Value}
        "Clear" { Get-ClearStyle -Background $CurrentStyle.background -Foreground $CurrentStyle.foreground -Value $Value }
        Default { Get-ClearStyle -Background $CurrentStyle.background -Foreground $CurrentStyle.foreground -Value $Value }
    }
}