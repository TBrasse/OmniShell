using Core.Segment;

namespace Core.Style
{
	public interface IStyle
	{
		string Name { get; }

		ISegment ApplyStyle(ISegment current, ISegment? previous, ISegment? next);
	}
}