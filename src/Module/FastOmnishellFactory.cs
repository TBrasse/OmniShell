using Core;
using Core.Painter;
using Core.Resolver;
using Core.Segments;
using Core.Shell;
using Core.Styles;

namespace Module
{
	internal class FastOmnishellFactory
	{
		public static IOmnishell BuildOmnishell()
		{
			IPSContext shellContext = new HostPSContext();
			PowershellExecutor shell = new PowershellExecutor
			(
				new HostPSSettingsProvider
				(
					shellContext
				)
			);
			return new Omnishell
			(
				new ConfigReader
				(
					new FileConfigurationReader
					(
						new PathProvider()
					),
					new PowershellExecutor
					(
						new HostPSSettingsProvider
						(
							shellContext
						)
					)
				),
				new ConfigWriter
				(
					new FileConfigurationWriter
					(
						new PathProvider()
					)
				),
				new SegmentRegistry
				(
					new AbstractSegment[] {
						new AzContextSegment(),
						new DateSegment(),
						new GitSegment(),
						new NewLineSegment(),
						new PathSegment(),
						new PlatformSegment(),
						new PromptSegment()
					}
				),
				new SegmentResolver
				(
					shell
				)
				,
				new SegmentPainter
				(
					new StyleRegistry
					(
						new IStyle[] {
							new ClearStyle(),
							new RibbonStyle()
						}
					)
				),
				new ModulePrinter
				(
					shellContext
				),
				shellContext
			);
		}
	}
}
