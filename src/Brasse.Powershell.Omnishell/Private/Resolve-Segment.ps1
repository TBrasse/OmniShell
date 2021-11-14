function Resolve-Segment {
    param(
        [Parameter(ValueFromPipeline)]
        [hashtable] $Segment
    )
    process {
        try {
            $resolved = ""
            foreach ($expression in $Segment.expressions.expression) {
                $resolved += (Invoke-Expression $expression)
            }
            $shouldRender = $true
            foreach ($if in $Segment.expressions.if) {
                if ($false -eq (Invoke-Expression $if)) {
                    $shouldRender = $false
                    break
                }
            }
        }
        catch {
            Write-Error "segment $($Segment.name) thrown error $_"
            return @{}
        }
        [PSCustomObject]@{
            "Name"       = $Segment.Name
            "Expression" = $resolved
            "Length"     = $resolved.Length
            "Prompt"     = $Segment.prompt
            "If"         = $shouldRender
        }
    }
}