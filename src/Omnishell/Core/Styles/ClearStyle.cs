using Core.Painter;
using Core.Segments;

namespace Core.Styles;

public class ClearStyle : IStyle
{
	public string Name => "clear";

	public ISegment ApplyStyle
	(
		ISegment current,
		ISegment? previous,
		ISegment? next
	)
	{
		current.Prefix = new PaintedString();
		current.Center = new PaintedString
		{
			String = current.Value
		};
		current.Suffix = new PaintedString();
		return current;
	}
}
