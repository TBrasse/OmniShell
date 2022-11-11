using System.Management.Automation;

internal class HostPSSettingsProvider : IPSSettingProvider
{
	private readonly IPSContext _context;

	public HostPSSettingsProvider
	(
		IPSContext context
	){
		_context = context;
	}

	public string WorkingDirectory => _context.WorkingDir;

	public PSInvocationSettings GetSettings()
	{
		return new PSInvocationSettings {
			Host = _context.Host,
		};
	}
}