namespace Core.Painter;

public class PaintedString
{
	public string String { get; internal set; } = string.Empty;
	public ConsoleColor Background { get; internal set; } = ConsoleColor.Black;
	public ConsoleColor Foreground { get; internal set; } = ConsoleColor.White;
}