using Core.Painter;
using Core.Shell;

namespace Core.Segments;

public class GitSegment : ISegment
{
	public string Name { get; set; } = "git";
	public string Expression { get; } = "git branch --show-current";
	public Format Format { get; set; }
	public string Value { get; set; }
	public PaintedString Prefix { get; set; }
	public PaintedString Center { get; set; }
	public PaintedString Suffix { get; set; }

	public bool Resolve(IShellExecutor shell)
	{
		PowershellResult result = shell.Execute(Expression);
		Value = result.Value;
		return result.Successfull && !string.IsNullOrEmpty(result.Value);
	}
}
