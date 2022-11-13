using System.Management.Automation;

namespace Core.Shell;

public class DefaultPSSettingsProvider : IPSSettingProvider
{
	public string WorkingDirectory { get; } = Directory.GetCurrentDirectory();

	public PSInvocationSettings GetSettings()
	{
		return new PSInvocationSettings();
	}
}
