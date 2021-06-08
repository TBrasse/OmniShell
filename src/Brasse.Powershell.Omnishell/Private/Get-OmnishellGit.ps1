function Get-OmnishellGit {

    $fileTypes = @{}
    $result = ""
    if (git rev-parse --is-inside-work-tree) {
        $branch = git branch --show-current
        $status = git status -s
        $commits = git log --oneline origin/$branch..HEAD

        $result += $branch
        $status | ForEach-Object {
            $null = $_ -match "\s*(?<type>.*) (.*)"
            $fileTypes[$Matches.type] ++
        }
        if($commits.Count -ne 0) {
            $fileTypes["C"] = $commits.Count
        }
        $result += '['
        if ($fileTypes.Count -gt 0) {
            $result += foreach ($type in $fileTypes.Keys) {
                "$type$($fileTypes[$type])"
            }
        } else {
            $result += "synced"
        }
        $result += ']'
    }
    $result
}