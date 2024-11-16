using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Core;
using Core.Painter;
using Core.Utils;

namespace Module
{
	internal static class ConfigFile
	{

		public static void SetupConfigFile()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();

			string omnishellAppData = GetOmnishellAppDataLocation();
			string localConfigLocation = Path.Combine(omnishellAppData, Constants.ConfigName);
			if (!Path.Exists(localConfigLocation))
			{
				Directory.CreateDirectory(omnishellAppData);
				//string defaultConfig = GetDefaultConfig(assembly);
				string defaultConfig = CreateConfig();
				File.WriteAllText(localConfigLocation, defaultConfig);
				//File.Copy(defaultConfig, localConfigLocation);
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
			string srcConfig = Path.Combine(pi.FullName, Constants.ConfigName);
			return srcConfig;
		}

		private static string CreateConfig()
		{
			Configuration config = new Configuration();
			config.Version = "0.4.0";
			config.Switch = "switch([Environment]::OSVersion.Platform){ 'Win32NT'{'default'} 'Unix'{'Unix'}}";
			config.Profiles = new Dictionary<string, Profile> {
				{
					"default", new Profile() {
						Order = new[]{
							"platform", "date", "pid", "git", "azcontext", "newLine",
							"path", "newLine",
							"prompt"
						},
						Segments = new Dictionary<string, string> {
							{ "pid", "$PID" }
						}
					}
				},
				{
					"Unix", new Profile() {
						Order = new[]{
							"platform", "date", "pid", "git", "azcontext", "newLine",
							"path", "newLine",
							"prompt"
						},
						Segments = new Dictionary<string, string> {
							{ "pid", "$PID" }
						}
					}
				}
			};
			config.Formats = new Dictionary<string, Format> {
				{
					"platform", new Format() {
						Style = "ribbon",
						Foreground = ConsoleColor.Black,
						Background = ConsoleColor.Blue
					}
				},
				{
					"date", new Format() {
						Style = "ribbon",
						Foreground = ConsoleColor.Black,
						Background = ConsoleColor.DarkGray
					}
				},
				{
					"pid", new Format() {
						Style = "ribbon",
						Foreground = ConsoleColor.Gray,
						Background = ConsoleColor.DarkBlue
					}
				},
				{
					"azcontext", new Format() {
						Style = "ribbon",
						Foreground = ConsoleColor.Black,
						Background = ConsoleColor.DarkGray
					}
				},
				{
					"git", new Format() {
						Style = "ribbon",
						Foreground = ConsoleColor.Black,
						Background = ConsoleColor.Green
					}
				},
				{
					"vpnTest", new Format() {
						Style = "ribbon",
						Foreground = ConsoleColor.Black,
						Background = ConsoleColor.Red
					}
				},
				{
					"newLine", new Format() {
						Style = "clear"
					}
				},
				{
					"path", new Format() {
						Style = "clear",
						Foreground = ConsoleColor.White
					}
				},
				{
					"prompt", new Format() {
						Style = "clear",
						Foreground = ConsoleColor.White
					}
				}
			};
			return Serializer.SerializeToYaml(config);
		}
	}
}