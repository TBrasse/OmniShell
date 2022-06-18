using System.Management.Automation;

namespace Omnishell.Core
{
	[Cmdlet(VerbsCommon.Get, "Prompt")]
	public class GetPrompt : Cmdlet
	{
		private readonly IOmnishell omnishell = OmnishellFactory.GetOmnishell();

		protected override void ProcessRecord()
		{
			omnishell.PrintPrompt();
			WriteObject("");
		}
	}
}