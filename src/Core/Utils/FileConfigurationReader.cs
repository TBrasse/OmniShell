using System.Text;

namespace Core.Utils;

public class FileConfigurationReader : IConfigurationReader
{
	private readonly IPathProvider _pathProvider;
	private readonly IObjectRepository _objectRepository;

	public FileConfigurationReader
	(
		IPathProvider pathProvider,
		IObjectRepository objectRepository
	)
	{
		_pathProvider = pathProvider;
		_objectRepository = objectRepository;
	}

	public void ReadAndSet()
	{
		string configurationPath = _pathProvider.GetConfigurationPath();
		string rawConfiguration = File.ReadAllText(configurationPath, Encoding.UTF8);
		if (configurationPath.EndsWith(".json"))
		{
			_objectRepository.Configuration = Serializer.SerializeFromJson(rawConfiguration);
		}
		else if (configurationPath.EndsWith(".yml"))
		{
			_objectRepository.Configuration = Serializer.SerializeFromYaml(rawConfiguration);
		}
		else
		{
			throw new NotSupportedException($"file format not supported: {configurationPath}");
		}
	}
}
