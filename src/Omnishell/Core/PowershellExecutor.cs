using Core;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Management.Automation;
using System.Text;

public class PowershellExecutor : IShellExecutor
{
    public string Execute(string expression)
    {
        var powershell = PowerShell.Create();
        powershell.AddScript(expression);
        Collection<PSObject> results = powershell.Invoke();
        StringBuilder stringBuilder = new StringBuilder();
        foreach (PSObject result in results)
        {
            stringBuilder.Append(result.ToString());
        }
        return stringBuilder.ToString();
    }

    public string Execute(string[] expressions)
    {
        var powershell = PowerShell.Create();
        foreach (var expression in expressions)
        {
            powershell.AddScript(expression);
        }
        Collection<PSObject> results = powershell.Invoke();
        StringBuilder stringBuilder = new StringBuilder();
        foreach (PSObject result in results)
        {
            stringBuilder.Append(result.ToString());
        }
        return stringBuilder.ToString();
    }
}