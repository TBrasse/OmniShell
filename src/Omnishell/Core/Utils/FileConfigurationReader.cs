using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Converters = {
                new JsonStringEnumConverter()
            }
        };
        Configuration configuration = JsonSerializer.Deserialize<Configuration>(rawConfiguration, options);
        return configuration;
    }
}
