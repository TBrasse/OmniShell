function Get-PromptSegment {
    @{
        "name"   = "prompt"
        "prompt" = "if(`$PSDebugContext) { '[DBG]> ' } else { '> ' }"
    }
}