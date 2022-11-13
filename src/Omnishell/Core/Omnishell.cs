using Core.Painter;
using Core.Resolver;
using Core.Segments;
using Core.Shell;
using Core.Utils;

namespace Core;

public class Omnishell : IOmnishell
{
	private readonly IConfigurationReader _configurationReader;
	private readonly IShellExecutor _shell;
	private readonly ISegmentRegistry _segmentProvider;
	private readonly ISegmentResolver _segmentResolver;
	private readonly ISegmentPainter _segmentPainter;
	private readonly ISegmentPrinter _segmentPrinter;

	public Omnishell
	(
		IConfigurationReader configurationReader,
		IShellExecutor shell,
		ISegmentRegistry segmentProvider,
		ISegmentResolver segmentResolver,
		ISegmentPainter segmentPainter,
		ISegmentPrinter segmentPrinter
	)
	{
		_configurationReader = configurationReader;
		_shell = shell;
		_segmentProvider = segmentProvider;
		_segmentResolver = segmentResolver;
		_segmentPainter = segmentPainter;
		_segmentPrinter = segmentPrinter;
	}

	public void PrintPrompt()
	{
		Configuration configuration = _configurationReader.Read();
		PowershellResult profileResult = _shell.Execute(configuration.Switch);
		string profileName = profileResult.Successfull ? profileResult.Value : "default";
		Profile profile = configuration.Profiles[profileName];
		ISegment[] orderedSegments = _segmentProvider.GetSegments(profile.LinkedOrder);
		ISegment[] resolvedSegments = _segmentResolver.ResolveSegments(orderedSegments);
		ISegment[] paintedSegments = _segmentPainter.PaintSegments(resolvedSegments, profile.Formats);
		_segmentPrinter.Print(paintedSegments);
	}
}