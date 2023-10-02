using System.Management.Automation;

namespace Core.Shell;

public class DefaultPSSettingsProvider : IPSSettingProvider
{
	public string WorkingDirectory { get; } = "D:\\Workspace\\Projects\\OmniShell\\";// Directory.GetCurrentDirectory();

	public PSInvocationSettings GetSettings()
	{
		return new PSInvocationSettings();
	}
}
