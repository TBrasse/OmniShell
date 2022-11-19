using Core;
using System.Management.Automation;

namespace Module;

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
		_context.Host = Host;
		_context.WorkingDir = SessionState.Path.CurrentFileSystemLocation.Path;
	}

	protected override void ProcessRecord()
	{
		WriteObject(_omnishell.PrintPrompt());
	}
}
