using Core.Shell;

namespace Core;

public class ConfigWriter : IConfigWriter
{
	private readonly IConfigurationWriter _configurationWriter;

	public ConfigWriter
	(
		IConfigurationWriter configurationWriter
	)
	{
		_configurationWriter = configurationWriter;
	}

	public void Write(Configuration configuration)
	{
		_configurationWriter.Write(configuration);
	}
}
