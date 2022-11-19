using Core.Segments;

namespace Core.Painter;

public interface ISegmentPainter
{
	AbstractSegment[] PaintSegments(AbstractSegment[] orderedSegments, Dictionary<string, Format> formats);
}