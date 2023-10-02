using Core.Shell;

namespace Core.Segments;

public class PathSegment : AbstractSegment
{
	private string _expression = "pwd";

	public PathSegment()
	{
		Name = "path";
	}

	public override bool Resolve(IShellExecutor shell)
	{
		PowershellResult result = shell.Execute(_expression);
		Value = result.Value;
		return result.Successfull && !string.IsNullOrEmpty(result.Value);
	}
}