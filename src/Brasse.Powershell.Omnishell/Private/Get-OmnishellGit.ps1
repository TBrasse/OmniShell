function Get-OmnishellGit {

    $fileTypes = @{}
    $result = ""
    if (Test-Path .git) {
        $branch = git branch --show-current
        $status = git status -s
        $commits = git log --oneline origin/$branch..HEAD

        $result += $branch
        $status | ForEach-Object {
            $null = $_ -match "\s*(?<type>.*) (.*)"
            $fileTypes[$Matches.type] ++
        }

        $result += '['
        if ($fileTypes.Count -gt 0) {
            $result += foreach ($type in $fileTypes.Keys) {
                "$type$($fileTypes[$type])"
            }
        }
        if($commits.Count -eq 0) {
            $result += "synced"
        } else {
            $result += " C$($commits.Count)"
        }
        $result += ']'
    }
    $result
}