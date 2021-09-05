function Get-OmnishellGit {

    $fileTypes = @{}
    $result = ""
    if (git rev-parse --is-inside-work-tree 2>0) {
        $branch = git branch --show-current 2>0
        $result += $branch
        if([Environment]::OSVersion.Platform -ne "UNIX"){
            $status = git status -s 2>0
            $commits = git log --oneline origin/$branch..HEAD 2>0

            $status | ForEach-Object {
                $null = $_ -match "\s*(?<type>\S*) .*"
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
    }
    $result
}