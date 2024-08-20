using Core.Painter;
using Core.Segments;

namespace Core.Utils
{
	public interface IObjectRepository
	{
		Configuration Configuration { get; set; }
		Profile Profile { get; set; }
		Dictionary<string, Format> Formats { get; set; }
		string Prompt { get; set; }
		AbstractSegment[] ResolvedRepository { get; set; }
		AbstractSegment[] OrderedSegments { get; set; }
		AbstractSegment[] PaintedSegments { get; set; }
	}
}