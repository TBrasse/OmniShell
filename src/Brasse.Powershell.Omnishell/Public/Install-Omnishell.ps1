function Install-Omnishell {
    [CmdletBinding(SupportsShouldProcess)]
    Param()
    $value = '
    Import-Module Omnishell
    function prompt {
        Get-Prompt
    }
    '
    if($PSCmdlet.ShouldProcess('$profile',"adding Omnisharp prompt")){
        Add-Content `
            -Path $profile `
            -Value $value `
            -WhatIf:$WhatIfPreference
    }
}