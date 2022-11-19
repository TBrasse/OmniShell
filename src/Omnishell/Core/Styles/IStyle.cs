using Core.Segments;

namespace Core.Styles;

public interface IStyle
{
	string Name { get; }
	AbstractSegment ApplyStyle(AbstractSegment current, AbstractSegment? previous, AbstractSegment? next);
}