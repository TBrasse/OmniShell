using Core.Segment;

public interface ISegmentResolver
{
	ISegment[] ResolveSegments(ISegment[] orderedSegments);
}