using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnishell.Core
{
    internal class Test : ITest
    {
        private string _filename;

        public Test()
        {
            _filename = Path.GetRandomFileName();
        }

        public string GetTest()
        {
            return _filename;
        }
    }
}
