using System.Text;

namespace Core.Utils;

public class FileConfigurationReader : IConfigurationReader
{
	private readonly IPathProvider _pathProvider;

	public FileConfigurationReader
	(
		IPathProvider pathProvider
	)
	{
		_pathProvider = pathProvider;
	}

	public Configuration Read()
	{
		string configurationPath = _pathProvider.GetConfigurationPath();
		string rawConfiguration = File.ReadAllText(configurationPath, Encoding.UTF8);
		if (configurationPath.EndsWith(".json"))
		{
			return Serializer.SerializeFromJson(rawConfiguration);
		}
		else if (configurationPath.EndsWith(".yml"))
		{
			return Serializer.SerializeFromYaml(rawConfiguration);
		}
		else
		{
			throw new NotSupportedException($"file format not supported: {configurationPath}");
		}
	}
}
