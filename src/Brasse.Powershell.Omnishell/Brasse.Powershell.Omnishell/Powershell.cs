using System.Collections.Generic;
using System.Management.Automation;


namespace Omnishell.Core
{
    internal class Powershell : IShell
    {
        public IEnumerable<string> Execute(string expression)
        {
            var powershell = PowerShell.Create();
            powershell.AddScript(expression);
            foreach (PSObject result in powershell.Invoke())
            {
                yield return result.ToString();
            }
        }

        public IEnumerable<string> Execute(string[] expressions)
        {
            var powershell = PowerShell.Create();
            foreach (string expression in expressions)
            {
                powershell.AddScript(expression);
            }
            foreach (PSObject result in powershell.Invoke())
            {
                yield return result.ToString();
            }
        }

        public IEnumerable<string> Execute(BaseSegment segment)
        {
            var powershell = PowerShell.Create();
            foreach (string expression in segment.Expressions)
            {
                powershell.AddScript(expression);
            }
            foreach (PSObject result in powershell.Invoke())
            {
                yield return result.ToString();
            }
        }
    }
}
