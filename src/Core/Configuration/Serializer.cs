using System.Text.Json;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace Core
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
			Configuration ?configuration = JsonSerializer.Deserialize<Configuration>(rawConfiguration, options);
			if(configuration == null){
				throw new Exception("fatal error while deserializing configuration.");
			}
			return configuration;
		}

		internal static string SerializeToJson(Configuration configuration)
		{
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				Converters = {
				new JsonStringEnumConverter()
			}
			};
			return JsonSerializer.Serialize(configuration, options);
		}

		public static Configuration SerializeFromYaml(string rawConfiguration)
		{
			IDeserializer deserializer = new DeserializerBuilder().Build();
			return deserializer.Deserialize<Configuration>(rawConfiguration);
		}

		internal static string SerializeToYml(Configuration configuration)
		{
			ISerializer serializer = new SerializerBuilder().Build();
			return serializer.Serialize(configuration);
		}
	}
}