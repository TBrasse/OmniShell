using Core.Utils;
using System.Management.Automation;

namespace Module;

[Cmdlet(VerbsCommon.Get, "ConfigPath")]
[OutputType(typeof(string))]
public class GetConfigPath : PSCmdlet
{
	private static IPathProvider pathProvider;

	public GetConfigPath()
	{
		if (pathProvider == null)
		{
			pathProvider = OmnishellFactory<ModuleConfiguration>.Build<IPathProvider>();
		}
	}

	protected override void ProcessRecord()
	{
		WriteObject(pathProvider.GetConfigurationPath());
	}
}
