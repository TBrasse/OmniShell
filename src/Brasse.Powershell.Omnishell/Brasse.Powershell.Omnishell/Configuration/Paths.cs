using System;
using System.IO;

namespace Omnishell.Core
{
    public class Paths : IPaths
    {
        public string GetConfigurationPath()
        {
            string appDir = GetAppFolder();
            return Path.Combine(appDir,Constants.ConfigName);
        }

        public string GetAppFolder()
        {
            string winAppDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(winAppDir, Constants.AppName);
        }
    }
}