using Core.Shell;

namespace Core.Segments;

public class DateSegment : AbstractSegment
{
	private string _expression = "Get-Date -Format HH:mm:ss";

	public DateSegment()
	{
		Name = "date";
	}

	public override bool Resolve(IShellExecutor shell)
	{
		PowershellResult result = shell.Execute(_expression);
		Value = result.Value;
		return result.Successfull && !string.IsNullOrEmpty(result.Value);
	}
}
