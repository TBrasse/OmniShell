using Microsoft.Extensions.DependencyInjection;

namespace Omnishell.Core
{
	internal interface ISetup
	{
		void Services(IServiceCollection services);
	}
}