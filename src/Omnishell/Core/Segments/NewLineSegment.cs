using Core.Shell;

namespace Core.Segments;

public class NewLineSegment : AbstractSegment
{
	public override string Name => "newLine";

	public override bool Resolve(IShellExecutor shell)
	{
		Value = "\n";
		return true;
	}
}
