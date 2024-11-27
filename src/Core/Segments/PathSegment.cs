using Core.Shell;

namespace Core.Segments;

public class PathSegment : AbstractSegment
{
	private readonly IPSContext _context;
	private string _expression = "pwd";

	public PathSegment
	(
		IPSContext context
	)
	{
		Name = "path";
		_context = context;
	}

	public override bool Resolve(IShellExecutor shell)
	{
		if (_context.WorkingDir != null)
		{
			Value = _context.PowershellPath;
			return true;
		}
		PowershellResult result = shell.Execute(_expression);
		Value = result.Value;
		return result.Successfull && !string.IsNullOrEmpty(result.Value);
	}
}