namespace Omnishell.Core
{
	internal class ConfigurationReader : IConfigurationReader
	{
		private readonly IFile file;
		private readonly IPaths paths;

		public ConfigurationReader(IFile file, IPaths paths)
		{
			this.file = file;
			this.paths = paths;
		}

		public Configuration Read()
		{
			var path = paths.GetConfigurationPath();
			string configContent = file.ReadAllText(path);
			return Configuration.Deserialize(configContent);
		}
	}
}
