function Get-OmnishellCurrentLocation{
    " $($executionContext.SessionState.Path.CurrentLocation)$(">" * ($nestedPromptLevel + 1)) "
}