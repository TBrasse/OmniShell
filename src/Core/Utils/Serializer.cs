using System.Text.Json;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace Core.Utils
{
	internal static class Serializer
	{

		public static Configuration SerializeFromJson(string rawConfiguration)
		{
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				Converters = {
				new JsonStringEnumConverter()
			}
			};
			return JsonSerializer.Deserialize<Configuration>(rawConfiguration, options);
		}

		public static Configuration SerializeFromYaml(string rawConfiguration)
		{
			IDeserializer deserializer = new DeserializerBuilder().Build();
			return deserializer.Deserialize<Configuration>(rawConfiguration);
		}
	}
}