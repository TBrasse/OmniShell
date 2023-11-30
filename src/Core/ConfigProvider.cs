using Core.Painter;
using Core.Shell;
using Core.Utils;

namespace Core;

public class ConfigProvider : IConfigProvider
{
	private readonly IShellExecutor _shell;

	public ConfigProvider
	(
		IShellExecutor shell
	)
	{
		_shell = shell;
	}

	public Dictionary<string, Format> GetFormats(Configuration configuration, Profile profile)
	{
		Dictionary<string, Format> formats = configuration.Formats;
		foreach (var formatName in profile.Formats.Keys)
		{
			if (formats.ContainsKey(formatName))
			{
				formats[formatName] = profile.Formats[formatName];
			}
			else
			{
				formats.Add(formatName, profile.Formats[formatName]);
			}
		}
		return formats;
	}

	public Profile GetProfile(Configuration configuration)
	{
		PowershellResult profileResult = _shell.Execute(configuration.Switch);
		string profileName = profileResult.Successfull ? profileResult.Value : "default";
		return configuration.Profiles[profileName];
	}
}
