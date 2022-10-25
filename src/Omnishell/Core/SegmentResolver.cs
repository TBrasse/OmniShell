namespace Core
{
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
            foreach (ISegment segment in orderedSegments)
            {
                segment.ResolvedValue = _shell.Execute(segment.Expressions);
            }
            return orderedSegments;
        }
    }
}
