using Core.Shell;

namespace Core.Segments;

public class PromptSegment : AbstractSegment
{
	public PromptSegment()
	{
		IsPrompt = true;
	}

	public override string Name => "prompt";

	public override bool Resolve(IShellExecutor shell)
	{
		Value = "> ";
		return true;
	}
}
