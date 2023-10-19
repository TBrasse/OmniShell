using Core.Shell;

namespace Core;

public class ConfigReader : IConfigReader
{
	private readonly IConfigurationReader _configurationReader;
	private readonly IShellExecutor _shell;

	public ConfigReader
	(
		IConfigurationReader configurationReader,
		IShellExecutor shell
	)
	{
		_configurationReader = configurationReader;
		_shell = shell;
	}

	public Configuration GetConfiguration()
	{
		return _configurationReader.Read();
	}

	public Profile GetProfile()
	{
		Configuration configuration = _configurationReader.Read();
		PowershellResult profileResult = _shell.Execute(configuration.Switch);
		string profileName = profileResult.Successfull ? profileResult.Value : "default";
		return configuration.Profiles[profileName];
	}
}
