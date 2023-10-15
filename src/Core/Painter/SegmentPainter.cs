using Core.Styles;
using Core.Segments;

namespace Core.Painter;

public class SegmentPainter : ISegmentPainter
{
    private readonly IStyleRegistry _styleRegistry;

    public SegmentPainter
    (
        IStyleRegistry styleRegistry
    )
    {
        _styleRegistry = styleRegistry;
    }

    public AbstractSegment[] PaintSegments(AbstractSegment[] orderedSegments, Dictionary<string, Format> formats)
    {
        for (int index = 0; index < orderedSegments.Length; index++)
        {
			AbstractSegment previous = null, current, next = null;
            current = orderedSegments[index];
            current.Format = formats[current.Name];
            if (index >= 1)
            {
                previous = orderedSegments[index - 1];
                previous.Format = formats[previous.Name];
            }
            if (index < orderedSegments.Length - 1 && orderedSegments.Length > 1)
            {
                next = orderedSegments[index + 1];
                next.Format = formats[next.Name];
            }
            IStyle style = _styleRegistry.GetStyle(current.Format.Style);
            style.ApplyStyle(current, previous, next);
        }
        return orderedSegments;
    }
}
