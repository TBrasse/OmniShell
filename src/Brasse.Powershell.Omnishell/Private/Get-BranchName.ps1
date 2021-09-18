function Get-BranchName {
    $current = Get-Item .
    while ($null -ne $current) {
        $git = Join-Path $current.FullName -ChildPath ".git"
        if (Test-Path $git) {
            $head = Get-Content -Path (Join-Path -Path $git -ChildPath "HEAD")
            if ($head -match "ref: refs/heads/(?<branch>.*)") {
                $Matches.branch
                return
            }
        }
        $current = $current.Parent
    }
}