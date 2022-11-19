using Microsoft.Extensions.DependencyInjection;
using Module;
using Core.Painter;
using Core.Shell;
using Core.Resolver;
using Core.Segments;
using Core.Styles;
using Core.Utils;
using Core;

public class ModuleConfiguration : ServiceConfiguration
{
	public override void ServiceCollection(IServiceCollection services)
	{
		services.AddSingleton<IOmnishell, Omnishell>();
		services.AddSingleton<IConfigurationReader, FileConfigurationReader>();
		services.AddSingleton<IPathProvider, PathProvider>();
		services.AddSingleton<IShellExecutor, PowershellExecutor>();
		services.AddSingleton<IProfileProvider, ProfileProvider>();
		services.AddSingleton<AbstractSegment, AzContextSegment>();
		services.AddSingleton<AbstractSegment, DateSegment>();
		services.AddSingleton<AbstractSegment, GitSegment>();
		services.AddSingleton<AbstractSegment, NewLineSegment>();
		services.AddSingleton<AbstractSegment, PathSegment>();
		services.AddSingleton<AbstractSegment, PlatformSegment>();
		services.AddSingleton<AbstractSegment, PromptSegment>();
		services.AddSingleton<ISegmentRegistry, SegmentRegistry>();
		services.AddSingleton<ISegmentResolver, SegmentResolver>();
		services.AddSingleton<ISegmentPainter, SegmentPainter>();
		services.AddSingleton<ISegmentPrinter, ModulePrinter>();
		services.AddSingleton<IStyle, ClearStyle>();
		services.AddSingleton<IStyle, RibbonStyle>();
		services.AddSingleton<IStyleRegistry, StyleRegistry>();
		services.AddSingleton<IPSSettingProvider, HostPSSettingsProvider>();
		services.AddSingleton<IPSContext, HostPSContext>();
	}
}