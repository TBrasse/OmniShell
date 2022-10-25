using Core;

public interface ISegmentPainter
{
    ISegment[] PaintSegments(ISegment[] orderedSegments, Dictionary<string, Format> formats);
}