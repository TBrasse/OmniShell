using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Omnishell.Core
{
    internal class Omnishell : IOmnishell
    {
        private static IOmnishell omnishell;

        public static IOmnishell GetOmnishell(Action<IServiceCollection> services)
        {
            if (omnishell == null)
            {
                var host = Host.CreateDefaultBuilder().ConfigureServices(services).Build();
                omnishell = host.Services.GetRequiredService<IOmnishell>();
            }
            return omnishell;
        }

        private readonly ITest _test;
        public Omnishell(ITest test)
        {
            _test = test;
        }

        public string GetTest()
        {
            return _test.GetTest();
        }
    }
}
