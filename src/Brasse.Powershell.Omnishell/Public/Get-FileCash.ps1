function Get-FileCash {
    param(
        [Parameter(Mandatory)]
        [string] $CashName
    )

    $cashLocation = "$env:APPDATA\Omnishell"

    $content = Get-Content -Path "$cashLocation\$CashName.json" -ErrorAction SilentlyContinue
    $content = $content -join ""
    $currentCash = ConvertFrom-Json -InputObject $content -AsHashtable -ErrorAction SilentlyContinue
    if ($null -eq $content -or $null -eq $currentCash) {
        @{}
    }
    $currentCash
}