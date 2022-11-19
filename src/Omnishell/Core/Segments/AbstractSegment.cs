using Core.Painter;
using Core.Shell;

namespace Core.Segments;

public abstract class AbstractSegment
{
	public string Name { get; set; }
	public Format Format { get; set; }
	public string Value { get; set; }
	public PaintedString Prefix { get; set; }
	public PaintedString Center { get; set; }
	public PaintedString Suffix { get; set; }
	public bool IsPrompt { get; set; } = false;
	abstract public bool Resolve(IShellExecutor shell);
}