using Core;
using Core.Painter;
using Core.Resolver;
using Core.Segments;
using Core.Shell;
using Core.Styles;
using Core.Utils;

namespace Module
{
	internal class FastOmnishellFactory
	{
		public static IOmnishell BuildOmnishell()
		{
			IPSContext shellContext = new HostPSContext();
			IPSSettingProvider settingProvider = new HostPSSettingsProvider
			(
				shellContext
			);
			PowershellExecutor shell = new PowershellExecutor
			(
				settingProvider
			);
			return new Omnishell
			(
				new FileConfigurationReader
				(
					new PathProvider()
				),
				new ConfigProvider
				(
					new PowershellExecutor
					(
						settingProvider
					)
				),
				new SegmentRegistry
				(
					new AbstractSegment[] {
						new AzContextSegment(),
						new DateSegment(),
						new GitSegment(settingProvider),
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
