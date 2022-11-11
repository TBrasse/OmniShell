using System.Management.Automation;

namespace Core
{
	public class DefaultPSSettingsProvider : IPSSettingProvider
	{
		public string WorkingDirectory { get; }

		public PSInvocationSettings GetSettings()
		{
			return new PSInvocationSettings();
		}
	}
}
