using Core.Painter;
using Core.Segments;

namespace Console
{
	internal class ConsolePrinter : ISegmentPrinter
	{
		public void Print(AbstractSegment[] paintedSegments)
		{
			foreach (AbstractSegment segment in paintedSegments)
			{
				System.Console.Write(segment.Prefix.String);
				System.Console.Write(segment.Center.String);
				System.Console.Write(segment.Suffix.String);
			}
		}
	}
}
