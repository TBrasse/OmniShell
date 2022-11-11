using Core.Style;
using Core.Segment;

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
				IStyle style = _styleProvider.GetStyle(current.Format.Style);
				//TODO: change setting values inside applystyle method
				style.ApplyStyle(current, previous, next);
			}
			return orderedSegments;
		}
	}
}
