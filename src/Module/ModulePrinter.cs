using Core;
using Core.Painter;
using Core.Segments;
using Core.Utils;

namespace Module;

internal class ModulePrinter : ISegmentPrinter
{
	private readonly IPSContext _context;
	private readonly IObjectRepository _objectRepository;

	public ModulePrinter
	(
		IPSContext context,
		IObjectRepository objectRepository
	)
	{
		_context = context;
		_objectRepository = objectRepository;
	}


	public void PrintSegments()
	{
		foreach (var segment in _objectRepository.PaintedSegments)
		{
			PrintSegment(segment);
		}
	}

	private void PrintSegment(AbstractSegment segment)
	{
		if (!string.IsNullOrEmpty(segment.Prefix.String))
			_context.Host.UI.Write
			(
				segment.Prefix.Foreground,
				segment.Prefix.Background,
				segment.Prefix.String
			);
		if (!string.IsNullOrEmpty(segment.Center.String))
			_context.Host.UI.Write
			(
				segment.Center.Foreground,
				segment.Center.Background,
				segment.Center.String
			);
		if (!string.IsNullOrEmpty(segment.Suffix.String))
			_context.Host.UI.Write
			(
				segment.Suffix.Foreground,
				segment.Suffix.Background,
				segment.Suffix.String
			);
	}
}