using Core.Segments;

namespace Core.Styles;

public interface IStyle
{
	string Name { get; }

	ISegment ApplyStyle(ISegment current, ISegment? previous, ISegment? next);
}