using Core.Painter;
using Core.Segments;

namespace Core.Utils
{
	public class ObjectRepository : IObjectRepository
	{
		public Configuration Configuration { get; set; }
		public Profile Profile { get; set; }
		public Dictionary<string, Format> Formats { get; set; }
		public string Prompt { get; set; }
		public AbstractSegment[] ResolvedRepository { get; set; }
		public AbstractSegment[] OrderedSegments { get; set; }
		public AbstractSegment[] PaintedSegments { get; set; }
	}
}