using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Text;

namespace Core.Shell;

public class PowershellExecutor : IShellExecutor
{
	IPSSettingProvider _settingProvider;
	private string _powershellPath;
	private PowerShell _powerShell;

	public PowershellExecutor
	(
		IPSSettingProvider settingProvider
	)
	{
		_settingProvider = settingProvider;
		_powerShell = PowerShell.Create();
	}

	public PowershellResult Execute(string command)
	{
		SetWorkingDir(_powerShell);
		return InvokeCommand(command);
	}

	public IEnumerable<PowershellResult> Execute(string[] commands)
	{
		SetWorkingDir(_powerShell);
		foreach (string command in commands)
		{
			yield return InvokeCommand(command);
		}
	}

	private PowershellResult InvokeCommand(string command)
	{
		_powerShell.AddStatement().AddScript(command);
		Collection<PSObject> result = _powerShell.Invoke();
		string resultString = ConvertToString(result);
		_powerShell.Commands.Clear();
		return PowershellResult.Succeed(resultString);
	}

	private void SetWorkingDir(PowerShell powershell)
	{
		string workingDir = _settingProvider.WorkingDirectory;
		if (workingDir != _powershellPath)
		{
			_powershellPath = workingDir;
			powershell.Runspace.SessionStateProxy.Path.SetLocation(_settingProvider.WorkingDirectory);
		}
	}

	private string ConvertToString(Collection<PSObject> results)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (PSObject result in results)
		{
			if (result != null)
				stringBuilder.Append(result);
		}
		return stringBuilder.ToString();
	}
}