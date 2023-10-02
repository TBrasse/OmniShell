using Core.Shell;

namespace Core.Segments;

public class PromptSegment : AbstractSegment
{
	public PromptSegment()
	{
		Name = "prompt";
		IsPrompt = true;
	}

	public override bool Resolve(IShellExecutor shell)
	{
		Value = ">";
		return true;
	}
}
