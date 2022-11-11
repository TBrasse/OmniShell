using System.Collections;
using System.Management.Automation;

public interface IPSSettingProvider
{
	string WorkingDirectory { get; }

	PSInvocationSettings GetSettings();
}