using Core.Segments;
using Core.Shell;

namespace Core.Resolver;

public class SegmentResolver : ISegmentResolver
{
    private readonly IShellExecutor _shell;

    public SegmentResolver
    (
        IShellExecutor shell
    )
    {
        _shell = shell;
    }

    public ISegment[] ResolveSegments(ISegment[] orderedSegments)
    {
        List<ISegment> resolvedSegments = new List<ISegment>();
        foreach (ISegment segment in orderedSegments)
        {
            bool shoulPrint = segment.Resolve(_shell);
            if (shoulPrint)
            {
                resolvedSegments.Add(segment);
            }
        }
        return resolvedSegments.ToArray();
    }
}
