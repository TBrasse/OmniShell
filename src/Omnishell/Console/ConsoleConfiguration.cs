using Console;
using Core;
using Core.Style;
using Microsoft.Extensions.DependencyInjection;

internal class ConsoleConfiguration : ServiceConfiguration
{
    public override void ServiceCollection(IServiceCollection services)
    {
        services.AddSingleton<IOmnishell, Omnishell>();
        services.AddSingleton<IConfigurationReader, FileConfigurationReader>();
        services.AddSingleton<IPathProvider, PathProvider>();
        services.AddSingleton<IShellExecutor, PowershellExecutor>();
        services.AddSingleton<ISegment, PathSegment>();
        services.AddSingleton<ISegmentRegistry, SegmentRegistry>();
        services.AddSingleton<ISegmentResolver, SegmentResolver>();
        services.AddSingleton<ISegmentPainter, SegmentPainter>();
        services.AddSingleton<IStyle, ClearStyle>();
        services.AddSingleton<IStyle, RibbonStyle>();
        services.AddSingleton<IStyleRegistry, StyleRegistry>();
        services.AddSingleton<ISegmentPrinter, ConsolePrinter>();
    }
}