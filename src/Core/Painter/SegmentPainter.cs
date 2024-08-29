using Core.Styles;
using Core.Segments;
using Core.Utils;

namespace Core.Painter;

public class SegmentPainter : ISegmentPainter
{
	private readonly IStyleRegistry _styleRegistry;
	private readonly IObjectRepository _objectRepository;

	public SegmentPainter
	(
		IStyleRegistry styleRegistry,
		IObjectRepository objectRepository
	)
	{
		_styleRegistry = styleRegistry;
		_objectRepository = objectRepository;
	}

	public void PaintSegments()
	{
		var segments = _objectRepository.ResolvedRepository;
		var formats = _objectRepository.Formats;
		for (int index = 0; index < segments.Length; index++)
		{
			AbstractSegment previous = null, current, next = null;
			current = segments[index];
			current.Format = formats[current.Name];
			if (index >= 1)
			{
				previous = segments[index - 1];
				previous.Format = formats[previous.Name];
			}
			if (index < segments.Length - 1 && segments.Length > 1)
			{
				next = segments[index + 1];
				next.Format = formats[next.Name];
			}
			IStyle style = _styleRegistry.GetStyle(current.Format.Style);
			style.ApplyStyle(current, previous, next);
		}
		_objectRepository.PaintedSegments = segments;
	}
}
