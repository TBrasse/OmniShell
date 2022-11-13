namespace Core.Segments;

public class SegmentRegistry : ISegmentRegistry
{
    private readonly Dictionary<string, ISegment> _segmentsRegistry;

    public SegmentRegistry
    (
        IEnumerable<ISegment> segments
    )
    {
        _segmentsRegistry = new Dictionary<string, ISegment>();
        foreach (ISegment segment in segments)
        {
            _segmentsRegistry.Add(segment.Name, segment);
        }
    }

    public ISegment[] GetSegments(LinkedList<string> linkedOrder)
    {
        List<ISegment> segments = new List<ISegment>();
        foreach (string segmentName in linkedOrder)
        {
            if (_segmentsRegistry.ContainsKey(segmentName))
                segments.Add(_segmentsRegistry[segmentName]);
        }
        return segments.ToArray();
    }
}
