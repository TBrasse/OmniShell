using Core.Shell;

namespace Core.Segments;

public class NewLineSegment : AbstractSegment
{
	public NewLineSegment()
	{
		Name = "newLine";
	}

	public override bool Resolve(IShellExecutor shell)
	{
		Value = "\n";
		return true;
	}
}
