function Get-OmnishellGit {

    $fileTypes = @{}
    $result = ""
    if (Test-Path .git) {
        $branch = git branch --show-current
        $status = git status -s

        $result += $branch
        $status | ForEach-Object {
            $null = $_ -match "\s*(?<type>.*) (.*)"
            $fileTypes[$Matches.type] ++
        }

        if ($fileTypes.Count -gt 0) {
            $result += '['
            $result += foreach ($type in $fileTypes.Keys) {
                "$type$($fileTypes[$type])"
            }
            $result += ']'
        } else {
            $result += "synced"
        }
    }
    $result
}