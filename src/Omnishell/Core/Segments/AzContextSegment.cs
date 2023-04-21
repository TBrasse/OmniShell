using Core.Shell;

namespace Core.Segments;

public class AzContextSegment : AbstractSegment
{
	private string _expression = "(Get-AzContext).Subscription.Name";

	public override string Name => "azcontext";

	public override bool Resolve(IShellExecutor shell)
	{
		ShellResult result = shell.Execute(_expression);
		Value = result.Value;
		return result.Successfull && !string.IsNullOrEmpty(result.Value);
	}
}
