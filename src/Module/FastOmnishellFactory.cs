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
			ObjectRepository objectRepository = new ObjectRepository();
			return new Omnishell
			(
				new FileConfigurationReader
				(
					new PathProvider(),
					objectRepository
				),
				new ConfigProvider
				(
					new PowershellExecutor
					(
						settingProvider
					),
					objectRepository
				),
				new SegmentRegistry
				(
					new AbstractSegment[] {
						new AzContextSegment(),
						new DateSegment(),
						new GitSegment(settingProvider),
						new NewLineSegment(),
						new PathSegment(shellContext),
						new PlatformSegment(),
						new PromptSegment()
					},
					objectRepository
				),
				new SegmentResolver
				(
					shell,
					objectRepository
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
					),
					objectRepository
				),
				new ModulePrinter
				(
					shellContext,
					objectRepository
				),
				shellContext,
				objectRepository
			);
		}
	}
}
