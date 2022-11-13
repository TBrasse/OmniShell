using Core.Segments;

namespace Core.Painter;

public interface ISegmentPrinter
{
	void Print(ISegment[] paintedSegments);
}