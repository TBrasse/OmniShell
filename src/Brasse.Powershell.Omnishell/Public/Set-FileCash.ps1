function Set-FileCash {
    param(
        [Parameter(Mandatory)]
        [string] $CashName,
        [Parameter(Mandatory)]
        [object] $CashValue
    )

    $cashLocation = "$env:APPDATA\Omnishell"
    $cashFile = "$cashLocation\$CashName.json"
    if (Test-Path $cashFile) {
        $null = New-Item -Path $cashFile -ItemType File -Force
    }
    $jsonContent = ConvertTo-Json -InputObject $CashValue -Depth 100
    Set-Content -Path $cashFile -Value $jsonContent
}