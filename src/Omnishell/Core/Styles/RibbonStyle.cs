using Core.Painter;
using Core.Segments;

namespace Core.Styles;

public class RibbonStyle : IStyle
{
	public string Name => "ribbon";

	public AbstractSegment ApplyStyle
	(
		AbstractSegment current,
		AbstractSegment? previous,
		AbstractSegment? next
	)
	{
		current.Prefix = new PaintedString
		{
			Background = Exists(previous) && SameStyle(current, previous) ? current.Format.Background : ConsoleColor.Black,
			Foreground = Exists(previous) && SameStyle(current, previous) ? previous.Format.Background : current.Format.Background,
			String = Exists(previous) && SameStyle(current, previous) ? "" : ""
		};
		current.Center = new PaintedString
		{
			Background = current.Format.Background,
			Foreground = current.Format.Foreground,
			String = $" {current.Value} "
		};
		current.Suffix = new PaintedString
		{
			Background = Exists(next) && SameStyle(current, next) ? next.Format.Background : ConsoleColor.Black,
			Foreground = Exists(next) && SameStyle(current, next) ? current.Format.Background : current.Format.Background,
			String = ""
		};
		return current;
	}

	private static bool Exists(AbstractSegment? segement)
	{
		return !string.IsNullOrEmpty(segement?.Value);
	}

	private static bool SameStyle(AbstractSegment? segment, AbstractSegment? segment2)
	{
		return segment?.Format.Style == segment2?.Format.Style;
	}
}
