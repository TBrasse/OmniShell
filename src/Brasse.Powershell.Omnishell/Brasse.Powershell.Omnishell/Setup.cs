using Microsoft.Extensions.DependencyInjection;
using Omnishell.Core.Segments;

namespace Omnishell.Core
{
    internal static class Setup
    {
        public static void Services(IServiceCollection services)
        {
            services.AddSingleton<IFile, File>();
            services.AddSingleton<IPaths, Paths>();
            services.AddSingleton<IShell, Powershell>();
            services.AddSingleton<IOmnishell, Omnishell>();
            services.AddSingleton<IStyleProvider, StyleProvider>();
            services.AddSingleton<IConsolePrinter, ConsolePrinter>();
            services.AddSingleton<IFormatProvider, FormatProvider>();
            services.AddSingleton<ISegmentResolver, SegmentResolver>();
            services.AddSingleton<ISegmentDictionary, SegmentDictionary>();
            services.AddSingleton<IConfigurationReader, ConfigurationReader>();
            //Segments
            services.AddSingleton<IBaseSegment, DateSegment>();
            services.AddSingleton<IBaseSegment, PathSegment>();
            services.AddSingleton<IBaseSegment, PromptSegment>();
            services.AddSingleton<IBaseSegment, NewLineSegment>();
            services.AddSingleton<IBaseSegment, PlatformSegment>();
        }
    }
}