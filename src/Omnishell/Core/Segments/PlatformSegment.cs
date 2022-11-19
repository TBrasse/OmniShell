using Core.Shell;

namespace Core.Segments;

public class PlatformSegment : AbstractSegment
{
	private string Expression = "switch([Environment]::OSVersion.Platform){ 'Win32NT'{''} 'Unix'{''} 'MacOSX'{''}}";

	public PlatformSegment()
	{
		Name = "platform";
	}

	public override bool Resolve(IShellExecutor shell)
	{
		PowershellResult result = shell.Execute(Expression);
		Value = result.Value;
		return result.Successfull && !string.IsNullOrEmpty(result.Value);
	}
}
