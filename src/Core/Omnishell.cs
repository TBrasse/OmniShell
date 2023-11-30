using Core.Painter;
using Core.Resolver;
using Core.Segments;
using Core.Utils;

namespace Core;

public class Omnishell : IOmnishell
{
	private readonly IConfigurationReader _configurationReader;
	private readonly IConfigProvider _configProvider;
	private readonly ISegmentRegistry _segmentRegistry;
	private readonly ISegmentResolver _segmentResolver;
	private readonly ISegmentPainter _segmentPainter;
	private readonly ISegmentPrinter _segmentPrinter;
	public IPSContext Context { get; }

	public Omnishell
	(
		IConfigurationReader configurationReader,
		IConfigProvider configProvider,
		ISegmentRegistry segmentRegistry,
		ISegmentResolver segmentResolver,
		ISegmentPainter segmentPainter,
		ISegmentPrinter segmentPrinter,
		IPSContext shellContext
	)
	{
		_configurationReader = configurationReader;
		_configProvider = configProvider;
		_segmentRegistry = segmentRegistry;
		_segmentResolver = segmentResolver;
		_segmentPainter = segmentPainter;
		_segmentPrinter = segmentPrinter;
		Context = shellContext;
	}

	public string PrintPrompt()
	{
		Configuration configuration = _configurationReader.Read();
		Profile profile = _configProvider.GetProfile(configuration);
		Dictionary<string, Format> formats = _configProvider.GetFormats(configuration, profile);
		_segmentRegistry.RegisterCustomSegments(profile.Segments);
		AbstractSegment[] orderedSegments = _segmentRegistry.GetSegments(profile.LinkedOrder);
		(AbstractSegment[] resolvedSegments, string[] promptSegments) = _segmentResolver.ResolveSegments(orderedSegments);
		AbstractSegment[] paintedSegments = _segmentPainter.PaintSegments(resolvedSegments, formats);
		_segmentPrinter.Print(paintedSegments);
		return string.Join("", promptSegments);
	}
}