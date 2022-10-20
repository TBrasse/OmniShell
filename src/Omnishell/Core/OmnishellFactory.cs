using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class OmnishellFactory<ServiceConfigurationType> where ServiceConfigurationType : ServiceConfiguration
{
    private static Lazy<IHost> lazyHost = new Lazy<IHost>(HostFactory);

    private static IHost HostFactory()
    {
        ServiceConfiguration configuration = Activator.CreateInstance<ServiceConfigurationType>();
        IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices(configuration.ServiceCollection)
            .Build();
        return host;
    }

    public static T2 Build<T2>()
    {
        return lazyHost.Value.Services.GetService<T2>();
    }
}