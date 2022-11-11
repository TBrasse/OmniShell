using Core;
using Core.Style;
using Core.Segment;
using Microsoft.Extensions.DependencyInjection;
using Module;

public class ModuleConfiguration : ServiceConfiguration
{
	public override void ServiceCollection(IServiceCollection services)
	{
		services.AddSingleton<IOmnishell, Core.Omnishell>();
		services.AddSingleton<IConfigurationReader, FileConfigurationReader>();
		services.AddSingleton<IPathProvider, PathProvider>();
		services.AddSingleton<IShellExecutor, PowershellExecutor>();
		services.AddSingleton<ISegment, AzContextSegment>();
		services.AddSingleton<ISegment, DateSegment>();
		services.AddSingleton<ISegment, GitSegment>();
		services.AddSingleton<ISegment, NewLineSegment>();
		services.AddSingleton<ISegment, PathSegment>();
		services.AddSingleton<ISegment, PlatformSegment>();
		services.AddSingleton<ISegment, PromptSegment>();
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