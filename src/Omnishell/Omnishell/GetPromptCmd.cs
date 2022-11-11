using System.Management.Automation;

namespace Omnishell.Module
{
	[Cmdlet(VerbsCommon.Get, "Prompt")]
	[OutputType(typeof(string))]
	public class GetPromptCmd : PSCmdlet
	{
		private static IOmnishell _omnishell;
		private static IPSContext _context;

		public GetPromptCmd()
		{
			if (_omnishell == null)
			{
				_omnishell = OmnishellFactory<ModuleConfiguration>.Build<IOmnishell>();
				_context = OmnishellFactory<ModuleConfiguration>.Build<IPSContext>();
			}
		}

		protected override void BeginProcessing()
		{
			WriteVerbose("Begin!");
		}

		// This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
		protected override void ProcessRecord()
		{
			_context.Host = Host;
			_context.WorkingDir = SessionState.Path.CurrentFileSystemLocation.Path;
			_omnishell.PrintPrompt();
			WriteObject("");
		}

		// This method will be called once at the end of pipeline execution; if no input is received, this method is not called
		protected override void EndProcessing()
		{
			WriteVerbose("End!");
		}
	}
}
