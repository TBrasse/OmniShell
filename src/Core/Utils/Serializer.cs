using System.Text.Json;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace Core.Utils
{
	public static class Serializer
	{

		public static Configuration DeserializeFromJson(string rawConfiguration)
		{
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				Converters = {
				new JsonStringEnumConverter()
			}
			};
			return JsonSerializer.Deserialize<Configuration>(rawConfiguration, options);
		}

		public static Configuration DeserializeFromYaml(string rawConfiguration)
		{
			IDeserializer deserializer = new DeserializerBuilder().Build();
			return deserializer.Deserialize<Configuration>(rawConfiguration);
		}

		public static string SerializeToYaml(Configuration config)
		{
			ISerializer serializer = new SerializerBuilder().Build();
			return serializer.Serialize(config);
		}
	}
}