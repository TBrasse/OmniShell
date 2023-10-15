using Core;
using System.Management.Automation;

namespace Module;

[Cmdlet(VerbsCommon.Get, "Prompt")]
[OutputType(typeof(string))]
public class GetPromptCmd : PSCmdlet
{
	private static IOmnishell _omnishell;

	public GetPromptCmd()
	{
		if (_omnishell == null)
		{
			_omnishell = OmnishellFactory<ModuleConfiguration>.Build<IOmnishell>();
			ConfigFile.SetupConfigFile();
		}
	}

	protected override void BeginProcessing()
	{
		_omnishell.Context.Host = Host;
		_omnishell.Context.WorkingDir = SessionState.Path.CurrentFileSystemLocation.Path;
	}

	protected override void ProcessRecord()
	{
		WriteObject(_omnishell.PrintPrompt());
	}
}
