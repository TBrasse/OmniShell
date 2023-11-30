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
		services.AddSingleton<IConfigProvider, ConfigProvider>();
		services.AddSingleton<AbstractSegment, DateSegment>();
		services.AddSingleton<AbstractSegment, NewLineSegment>();
		services.AddSingleton<AbstractSegment, PathSegment>();
		services.AddSingleton<AbstractSegment, PlatformSegment>();
		services.AddSingleton<AbstractSegment, GitSegment>();
		services.AddSingleton<AbstractSegment, PromptSegment>();
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