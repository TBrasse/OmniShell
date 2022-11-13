using Core.Segments;

namespace Core.Painter;

public interface ISegmentPainter
{
	ISegment[] PaintSegments(ISegment[] orderedSegments, Dictionary<string, Format> formats);
}