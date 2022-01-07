using Microsoft.Extensions.DependencyInjection;

namespace Omnishell.Core
{
    internal static class Setup
    {
        public static void Services(IServiceCollection services)
        {
            services.AddSingleton<ITest, Test>();
            services.AddSingleton<IFile, File>();
            services.AddSingleton<IPaths, Paths>();
            services.AddSingleton<IOmnishell, Omnishell>();
        }
    }
}