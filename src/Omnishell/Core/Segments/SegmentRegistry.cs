namespace Core.Segments;

public class SegmentRegistry : ISegmentRegistry
{
    private readonly Dictionary<string, AbstractSegment> _segmentsRegistry;

    public SegmentRegistry
    (
        IEnumerable<AbstractSegment> segments
    )
    {
        _segmentsRegistry = new Dictionary<string, AbstractSegment>();
        foreach (AbstractSegment segment in segments)
        {
            _segmentsRegistry.Add(segment.Name, segment);
        }
    }

    public AbstractSegment[] GetSegments(LinkedList<string> linkedOrder)
    {
        List<AbstractSegment> segments = new List<AbstractSegment>();
        foreach (string segmentName in linkedOrder)
        {
            if (_segmentsRegistry.ContainsKey(segmentName))
                segments.Add(_segmentsRegistry[segmentName]);
        }
        return segments.ToArray();
    }
}
