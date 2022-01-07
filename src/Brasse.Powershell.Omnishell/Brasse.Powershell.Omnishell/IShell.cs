using System.Collections.Generic;

namespace Omnishell.Core
{
    internal interface IShell
    {
        public IEnumerable<string> Execute(string expression);
        public IEnumerable<string> Execute(string[] expressions);
        public IEnumerable<string> Execute(BaseSegment segment);
    }
}