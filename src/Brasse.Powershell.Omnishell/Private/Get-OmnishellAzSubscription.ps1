function Get-OmnishellAzSubscription {
    $context = Get-AzContext
    if ($context) {
        $context.Subscription.Name
    } else {
        "No Az Login"
    }
}