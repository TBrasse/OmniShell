function Resolve-Segment {
    param(
        [Parameter(ValueFromPipeline)]
        [hashtable] $Segment,
        [hashtable] $Style
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
        $format = Get-Format @Style -Value $resolved
        [PSCustomObject]@{
            "Name"   = $Segment.Name
            "Length" = $format.prefix.Length + $format.segment.Length + $format.segment.Lenght
            "Format" = $format
            "Prompt" = $Segment.prompt
            "If"     = $shouldRender
        }
    }
}