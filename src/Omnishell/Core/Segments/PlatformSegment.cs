using Core.Painter;
using Core.Shell;

namespace Core.Segments;

public class PlatformSegment : ISegment
{
	public string Name { get; set; } = "platform";
	public string Expression { get; } = "switch([Environment]::OSVersion.Platform){ 'Win32NT'{''} 'Unix'{''} 'MacOSX'{''}}";
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
