using Core;
using Microsoft.Extensions.DependencyInjection;

internal class ConsoleConfiguration : ServiceConfiguration
{
    public override void ServiceCollection(IServiceCollection services)
    {
        services.AddSingleton<IOmnishell, Omnishell>();
        services.AddSingleton<IConfigurationReader, FileConfigurationReader>();
        services.AddSingleton<IPathProvider, PathProvider>();
    }
}