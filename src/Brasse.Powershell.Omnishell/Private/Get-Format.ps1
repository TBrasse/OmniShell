function Get-Format {
    param(
        [Parameter(Mandatory)]
        [string] $Format,
        # [Parameter(Mandatory)]
        [string] $Background,
        # [Parameter(Mandatory)]
        [string] $Foreground,
        [string] $Value
    )
    switch ($Format) {
        "Arrow" { Get-ArrowStyle -Background $Background -Foreground $Foreground -Value $Value }
        "Diamond" { Get-DiamondStyle -Background $Background -Foreground $Foreground -Value $Value }
        "Clear" { Get-ClearStyle -Background $Background -Foreground $Foreground -Value $Value }
        Default { Get-ClearStyle -Background $Background -Foreground $Foreground -Value $Value }
    }
}