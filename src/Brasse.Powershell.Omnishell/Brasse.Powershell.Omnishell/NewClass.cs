using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnishell.Core
{
    internal class NewClass : IObservable<string>
    {
        public IDisposable Subscribe(IObserver<string> observer)
        {
            observer.OnNext()
        }
    }
}
