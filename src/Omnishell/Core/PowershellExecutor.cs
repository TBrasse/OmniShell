using Core;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

public class PowershellExecutor : IShellExecutor
{
	IPSSettingProvider _settingProvider;

	public PowershellExecutor
	(
		IPSSettingProvider settingProvider
	)
	{
		_settingProvider = settingProvider;
	}


	public PowershellResult Execute(string command)
	{
		using Runspace runspace = RunspaceFactory.CreateRunspace();
		runspace.Open();
		runspace.SessionStateProxy.Path.SetLocation(_settingProvider.WorkingDirectory);
		using Pipeline pipeline = runspace.CreatePipeline();
		pipeline.Commands.AddScript(command);
		Collection<PSObject> results = pipeline.Invoke();
		if (pipeline.HadErrors)
		{
			var lastErrorMessage = pipeline.Error.ReadToEnd();
			return PowershellResult.Failed("Error");
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (PSObject result in results)
		{
			if (result != null)
				stringBuilder.Append(result.ToString());
		}
		runspace.Close();
		return PowershellResult.Succeed(stringBuilder.ToString());
	}
}