function Remove-Omnishell {
    [CmdletBinding(SupportsShouldProcess)]
    Param()
    if($PSCmdlet.ShouldProcess('$profile',"removing Omnisharp prompt")){
        $value = '
        Import-Module Omnishell
        function prompt {
            Get-Prompt
        }
        '
        $content = (Get-Content -Path $profile) -join "\n"
        $content = $content -replace $value, ""
        Set-Content -Path $profile -Value $content
    }
}