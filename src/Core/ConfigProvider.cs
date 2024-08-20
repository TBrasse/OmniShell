using Core.Painter;
using Core.Shell;
using Core.Utils;

namespace Core;

public class ConfigProvider : IConfigProvider
{
	private readonly IShellExecutor _shell;
	private readonly IObjectRepository _objectRepository;

	public ConfigProvider
	(
		IShellExecutor shell,
		IObjectRepository objectRepository
	)
	{
		_shell = shell;
		_objectRepository = objectRepository;
	}

	public void ReadAndSetFormats()
	{
		Dictionary<string, Format> formats = _objectRepository.Configuration.Formats;
		foreach (var formatName in _objectRepository.Profile.Formats.Keys)
		{
			if (formats.ContainsKey(formatName))
			{
				formats[formatName] = _objectRepository.Profile.Formats[formatName];
			}
			else
			{
				formats.Add(formatName, _objectRepository.Profile.Formats[formatName]);
			}
		}
		_objectRepository.Formats = formats;
	}

	public void ReadAndSetProfile()
	{
		PowershellResult profileResult = _shell.Execute(_objectRepository.Configuration.Switch);
		string profileName = profileResult.Successfull ? profileResult.Value : "default";
		_objectRepository.Profile = _objectRepository.Configuration.Profiles[profileName];
	}
}
