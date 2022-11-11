using Core;
using Core.Segment;

public interface ISegmentPainter
{
	ISegment[] PaintSegments(ISegment[] orderedSegments, Dictionary<string, Format> formats);
}