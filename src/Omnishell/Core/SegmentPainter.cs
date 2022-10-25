using Core.Style;

namespace Core
{
    public class SegmentPainter : ISegmentPainter
    {
        private readonly IStyleRegistry _styleProvider;

        public SegmentPainter
        (
            IStyleRegistry styleProvider
        )
        {
            _styleProvider = styleProvider;
        }

        public ISegment[] PaintSegments(ISegment[] orderedSegments, Dictionary<string, Format> formats)
        {
            //foreach (ISegment segment in orderedSegments)
            for (int index = 0; index < orderedSegments.Length; index++)
            {
                ISegment previous = null, current, next = null;
                current = orderedSegments[index];
                if (index >= 1)
                    previous = orderedSegments[index - 1];
                if (index < orderedSegments.Length - 1 && orderedSegments.Length >= 1)
                    next = orderedSegments[index + 1];
                Format format = formats[current.Name];
                string styleName = format.Style;
                IStyle style = _styleProvider.GetStyle(styleName);
                //TODO: change setting values inside applystyle method
                style.ApplyStyle(current, format, previous, next);
            }
            return orderedSegments;
        }
    }
}
