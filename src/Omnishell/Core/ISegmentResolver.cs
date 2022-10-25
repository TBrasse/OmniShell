using Core;

public interface ISegmentResolver
{
    ISegment[] ResolveSegments(ISegment[] orderedSegments);
}