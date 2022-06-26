using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Omnishell.Core.Styles;
using System;

namespace Omnishell.Core
{
    internal class Omnishell : IOmnishell
    {
        private static IOmnishell omnishell;

        public static IOmnishell GetOmnishell(Action<IServiceCollection> services)
        {
            if (omnishell == null)
            {
                var host = Host.CreateDefaultBuilder().ConfigureServices(services).Build();
                omnishell = host.Services.GetRequiredService<IOmnishell>();
            }
            return omnishell;
        }

        public Omnishell
        (
            ISegmentResolver segmentResolver,
            ISegmentDictionary segmentDictionary,
            IConsolePrinter printer
        )
        {
            _segmentResolver = segmentResolver;
            _segmentDictionary = segmentDictionary;
            _printer = printer;
        }

        private readonly ISegmentResolver _segmentResolver;
        private readonly ISegmentDictionary _segmentDictionary;
        private readonly IConsolePrinter _printer;

        public void PrintPrompt()
        {
            foreach (var segment in _segmentDictionary)
            {
                FormatedStyle formatedSegment = _segmentResolver.Resolve(segment);
                _printer.Print(formatedSegment);
            }
        }
    }
}
