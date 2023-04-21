using Core.Shell;
using Core.Utils;

namespace Core;

public class ProfileProvider : IProfileProvider
{
	private readonly IConfigurationReader _configurationReader;
	private readonly IShellExecutor _shell;

	public ProfileProvider
	(
		IConfigurationReader configurationReader,
		IShellExecutor shell
	)
	{
		_configurationReader = configurationReader;
		_shell = shell;
	}

	public Profile GetProfile()
	{
		Configuration configuration = _configurationReader.Read();
		ShellResult profileResult = _shell.Execute(configuration.Switch);
		string profileName = profileResult.Successfull ? profileResult.Value : "default";
		return configuration.Profiles[profileName];
	}
}
