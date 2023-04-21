using Core.Shell;

namespace Core.Segments;

public class DateSegment : AbstractSegment
{
	private string _expression = "Get-Date -Format HH:mm:ss";

	public override string Name => "date";

	public override bool Resolve(IShellExecutor shell)
	{
		ShellResult result = shell.Execute(_expression);
		Value = result.Value;
		return result.Successfull && !string.IsNullOrEmpty(result.Value);
	}
}
