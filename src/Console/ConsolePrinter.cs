using Core.Painter;
using Core.Segments;
using Core.Utils;

namespace Console
{
	internal class ConsolePrinter : ISegmentPrinter
	{
		private readonly IObjectRepository _objectRepository;

		ConsolePrinter(IObjectRepository objectRepository)
		{
			_objectRepository = objectRepository;
		}

		public void PrintSegments()
		{
			foreach (AbstractSegment segment in _objectRepository.PaintedSegments)
			{
				System.Console.Write(segment.Prefix.String);
				System.Console.Write(segment.Center.String);
				System.Console.Write(segment.Suffix.String);
			}
		}
	}
}
