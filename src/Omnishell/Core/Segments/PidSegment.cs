using Core.Shell;

namespace Core.Segments;

public class PidSegment : AbstractSegment
{
	public override string Name => "pid";

	public override bool Resolve(IShellExecutor shell)
	{
		ShellResult result = shell.Execute("$Pid");
		Value = result.Value;
		return !string.IsNullOrEmpty(result.Value);
	}
}
