using System;
using System.IO;
using System.Reflection;

namespace Module
{
	internal static class ConfigFile
	{

		public static void SetupConfigFile()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();

			string omnishellAppData = GetOmnishellAppDataLocation();
			string localConfigLocation = Path.Combine(omnishellAppData, "config.json");
			if (!Path.Exists(localConfigLocation))
			{
				Directory.CreateDirectory(omnishellAppData);
				string defaultConfig = GetDefaultConfig(assembly);
				File.Copy(defaultConfig, localConfigLocation);
			}
		}

		private static string GetOmnishellAppDataLocation()
		{
			string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string omnishellAppData = Path.Combine(appData, "Omnishell");
			return omnishellAppData;
		}

		private static string GetDefaultConfig(Assembly assembly)
		{
			DirectoryInfo pi = Directory.GetParent(assembly.Location);
			string srcConfig = Path.Combine(pi.FullName, "config.json");
			return srcConfig;
		}
	}
}