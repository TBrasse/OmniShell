function Get-FileCash {
    param(
        [Parameter(Mandatory)]
        [string] $CashName
    )

    $cashLocation = "$env:APPDATA\Omnishell"

    $content = Get-Content -Path "$cashLocation\$CashName.json" -ErrorAction SilentlyContinue
    $currentCash = $content | ConvertFrom-Json -AsHashtable -Depth 100 -ErrorAction SilentlyContinue
    if ($null -eq $content -or $null -eq $currentCash) {
        $currentCash = @{}
    }
    $currentCash
}