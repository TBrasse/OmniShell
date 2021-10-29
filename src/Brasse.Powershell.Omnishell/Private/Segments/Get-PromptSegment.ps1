function Get-PromptSegment {
    @{
        "prompt" = @{
            "prompt" = "if(`$PSDebugContext) { '[DBG]> ' } else { '> ' }"
        }
    }
}