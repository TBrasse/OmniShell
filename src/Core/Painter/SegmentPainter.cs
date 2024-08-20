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
		for (int index = 0; index < _objectRepository.OrderedSegments.Length; index++)
		{
			AbstractSegment previous = null, current, next = null;
			current = _objectRepository.OrderedSegments[index];
			current.Format = _objectRepository.Formats[current.Name];
			if (index >= 1)
			{
				previous = _objectRepository.OrderedSegments[index - 1];
				previous.Format = _objectRepository.Formats[previous.Name];
			}
			if (index < _objectRepository.OrderedSegments.Length - 1 && _objectRepository.OrderedSegments.Length > 1)
			{
				next = _objectRepository.OrderedSegments[index + 1];
				next.Format = _objectRepository.Formats[next.Name];
			}
			IStyle style = _styleRegistry.GetStyle(current.Format.Style);
			style.ApplyStyle(current, previous, next);
		}
		_objectRepository.PaintedSegments = _objectRepository.OrderedSegments;
	}
}
