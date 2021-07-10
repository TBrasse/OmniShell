function Set-FileCash {
    param(
        [Parameter(Mandatory)]
        [string] $CashName,
        [Parameter(Mandatory)]
        [object] $NewCash
    )

    $cashLocation = "$env:APPDATA\Omnishell"
    $cashFile = "$cashLocation\$CashName.json"

    # $content = Get-Content -Path $cashFile -ErrorAction SilentlyContinue
    # if ($null -ne $content) {
    #     # $currentCash = ConvertFrom-Json -InputObject $content -AsHashtable -ErrorAction SilentlyContinue
    # }
    # else {
        if(Test-Path $cashFile){
            $null = New-Item -Path $cashFile -ItemType File -Force
        }
    # }
    # if ($null -eq $currentCash) {
    #     $currentCash = @{}
    # }
    # foreach ($item in $NewCash.GetEnumerator()) {
    #     $currentCash[$item.Key] = $item.Value
    # }
    $jsonContent = ConvertTo-Json -InputObject $NewCash
    Set-Content -Path $cashFile -Value $jsonContent
}