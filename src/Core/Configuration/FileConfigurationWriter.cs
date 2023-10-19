using System.Text;

namespace Core;

public class FileConfigurationWriter : IConfigurationWriter
{
	private readonly IPathProvider _pathProvider;

	public FileConfigurationWriter
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

	public void Write(Configuration configuration)
	{
		string configurationPath = _pathProvider.GetConfigurationPath();
		string rawConfiguration;
		if (configurationPath.EndsWith(".json"))
		{
			rawConfiguration = Serializer.SerializeToJson(configuration);
		}
		else if (configurationPath.EndsWith(".yml"))
		{
			rawConfiguration = Serializer.SerializeToYml(configuration);
		}
		else
		{
			throw new NotSupportedException($"file format not supported: {configurationPath}");
		}
		File.WriteAllText(configurationPath, rawConfiguration);
	}
}
