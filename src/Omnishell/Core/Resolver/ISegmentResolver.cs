using Core.Segments;

namespace Core.Resolver;

public interface ISegmentResolver
{
	ISegment[] ResolveSegments(ISegment[] orderedSegments);
}