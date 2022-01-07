using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Omnishell.Core
{
    internal class Configuration
    {
        public string Version { get; set; }
        public string Switch { get; set; }
        public Dictionary<string, Profile> Profiles { get; set; }

        private static JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            Converters = {
                new JsonStringEnumConverter()
            }
        };

        internal static Configuration Deserialize(string jsonContent)
        {
            return JsonSerializer.Deserialize<Configuration>(jsonContent, serializerOptions);
        }

        internal static string Serialize(Configuration configuration)
        {
            return JsonSerializer.Serialize<Configuration>(configuration, serializerOptions);
        }
    }
}
