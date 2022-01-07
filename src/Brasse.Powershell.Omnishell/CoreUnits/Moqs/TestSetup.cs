using Microsoft.Extensions.DependencyInjection;

namespace Omnishell.Core
{
    internal static class TestSetup
    {
        public static void Services(IServiceCollection services)
        {
            services.AddSingleton<ITest, Test>();
            services.AddSingleton<IOmnishell, Omnishell>();
        }
    }
}