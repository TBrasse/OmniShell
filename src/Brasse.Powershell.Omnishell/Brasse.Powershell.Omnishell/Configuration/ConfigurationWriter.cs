namespace Omnishell.Core
{
    internal class ConfigurationWriter
    {
        private readonly IFile file;
        private readonly IPaths paths;

        public ConfigurationWriter(IFile file, IPaths paths)
        {
            this.file = file;
            this.paths = paths;
        }

        public void Write(Configuration configuration)
        {
            var path = paths.GetConfigurationPath();
            var configJson = Configuration.Serialize(configuration);
            file.WriteAllText(path, configJson);
        }
    }
}
