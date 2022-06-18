using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Omnishell.Core.Segments;
using Omnishell.Core.Styles;
using System;
using System.Collections.Generic;
using System.IO;

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

		public Omnishell(IConfigurationReader reader)
		{
			_configuration = reader.Read();
		}

		private readonly Configuration _configuration;

		public void PrintPrompt()
		{
			Profile profile = _configuration.Profiles[_configuration.Switch];
			ISegmentResolver resolver = new SegmentResolver(
				new Powershell(),
				new FormatProvider(),
				new StyleProvider(profile)
			);
			ISegmentDictionary dictionary = new SegmentDictionary(
				new List<IBaseSegment>
				{
					new DateSegment()
				}
			);
			var segments = dictionary.GetOrderedSegments(profile.LinkedOrder);
			IConsolePrinter printer = new ConsolePrinter();
			foreach (var segment in segments)
			{
				FormatedStyle formatedSegment = resolver.Resolve(segment);
				printer.Print(formatedSegment);
			}
		}
	}
}
