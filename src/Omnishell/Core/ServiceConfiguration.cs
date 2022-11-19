using Microsoft.Extensions.DependencyInjection;

public abstract class ServiceConfiguration
{
	public abstract void ServiceCollection(IServiceCollection services);
}