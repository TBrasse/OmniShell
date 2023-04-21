using Core.Shell;

namespace Core.Segments;

public class PlatformSegment : AbstractSegment
{
	private string Expression = "switch([Environment]::OSVersion.Platform){ 'Win32NT'{''} 'Unix'{''} 'MacOSX'{''}}";

	public override string Name => "platform";

	public override bool Resolve(IShellExecutor shell)
	{
		ShellResult result = shell.Execute(Expression);
		Value = result.Value;
		return result.Successfull && !string.IsNullOrEmpty(result.Value);
	}
}
