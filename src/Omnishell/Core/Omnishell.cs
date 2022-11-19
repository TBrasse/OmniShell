using Core.Painter;
using Core.Resolver;
using Core.Segments;

namespace Core;

public class Omnishell : IOmnishell
{
	private readonly IProfileProvider _profileProvider;
	private readonly ISegmentRegistry _segmentProvider;
	private readonly ISegmentResolver _segmentResolver;
	private readonly ISegmentPainter _segmentPainter;
	private readonly ISegmentPrinter _segmentPrinter;

	public Omnishell
	(
		IProfileProvider profileProvider,
		ISegmentRegistry segmentProvider,
		ISegmentResolver segmentResolver,
		ISegmentPainter segmentPainter,
		ISegmentPrinter segmentPrinter
	)
	{
		_profileProvider = profileProvider;
		_segmentProvider = segmentProvider;
		_segmentResolver = segmentResolver;
		_segmentPainter = segmentPainter;
		_segmentPrinter = segmentPrinter;
	}

	public string PrintPrompt()
	{
		Profile profile = _profileProvider.GetProfile();
		AbstractSegment[] orderedSegments = _segmentProvider.GetSegments(profile.LinkedOrder);
		(AbstractSegment[] resolvedSegments, string[] promptSegments) = _segmentResolver.ResolveSegments(orderedSegments);
		AbstractSegment[] paintedSegments = _segmentPainter.PaintSegments(resolvedSegments, profile.Formats);
		_segmentPrinter.Print(paintedSegments);
		return string.Join("", promptSegments);
	}
}