using Core.Segments;

namespace Core.Resolver;

public interface ISegmentResolver
{
	(AbstractSegment[], string[]) ResolveSegments(AbstractSegment[] orderedSegments);
}