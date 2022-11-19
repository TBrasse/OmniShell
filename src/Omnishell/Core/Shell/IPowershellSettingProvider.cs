using System.Collections;
using System.Management.Automation;

namespace Core.Shell;

public interface IPSSettingProvider
{
	string WorkingDirectory { get; }

	PSInvocationSettings GetSettings();
}
