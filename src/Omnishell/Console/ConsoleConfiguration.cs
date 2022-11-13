using Console;
using Core;
using Core.Painter;
using Core.Resolver;
using Core.Segments;
using Core.Shell;
using Core.Styles;
using Core.Utils;
using Microsoft.Extensions.DependencyInjection;

internal class ConsoleConfiguration : ServiceConfiguration
{
	public override void ServiceCollection(IServiceCollection services)
	{
		services.AddSingleton<IOmnishell, Omnishell>();
		services.AddSingleton<IConfigurationReader, FileConfigurationReader>();
		services.AddSingleton<IPathProvider, PathProvider>();
		services.AddSingleton<IShellExecutor, PowershellExecutor>();
		services.AddSingleton<ISegment, DateSegment>();
		services.AddSingleton<ISegment, NewLineSegment>();
		services.AddSingleton<ISegment, PathSegment>();
		services.AddSingleton<ISegment, PlatformSegment>();
		services.AddSingleton<ISegment, PromptSegment>();
		services.AddSingleton<ISegmentRegistry, SegmentRegistry>();
		services.AddSingleton<ISegmentResolver, SegmentResolver>();
		services.AddSingleton<ISegmentPainter, SegmentPainter>();
		services.AddSingleton<ISegmentPrinter, ConsolePrinter>();
		services.AddSingleton<IStyle, ClearStyle>();
		services.AddSingleton<IStyle, RibbonStyle>();
		services.AddSingleton<IStyleRegistry, StyleRegistry>();
		services.AddSingleton<ISegmentPrinter, ConsolePrinter>();
		services.AddSingleton<IPSSettingProvider, DefaultPSSettingsProvider>();
	}
}