using Core.Painter;
using Core.Segments;

namespace Module;

internal class ModulePrinter : ISegmentPrinter
{
	private readonly IPSContext _context;

	public ModulePrinter(IPSContext context)
	{
		_context = context;
	}


	public void Print(ISegment[] paintedSegments)
	{
		foreach (var segment in paintedSegments)
		{
			PrintSegment(segment);
		}
	}

	private void PrintSegment(ISegment segment)
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