using Core;
using System.Management.Automation;

namespace Module;

[Cmdlet(VerbsCommon.Set, "Option")]
[OutputType(typeof(string))]
public class SetOptionCmd : PSCmdlet
{
	private static IOmnishell _omnishell;

	[Parameter(Position=0)]
	public string Segment { get; set; }

	public SetOptionCmd()
	{
		if (_omnishell == null)
		{
			_omnishell = OmnishellFactory<ModuleConfiguration>.Build<IOmnishell>();
		}
	}

	protected override void BeginProcessing()
	{

	}

	protected override void ProcessRecord()
	{
		WriteObject(_omnishell.PrintPrompt());
	}
}
