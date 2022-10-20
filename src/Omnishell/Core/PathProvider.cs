namespace Core
{
    public class PathProvider : IPathProvider
    {
        public string GetConfigurationPath()
        {
            string appFolder = GetAppFolderPath();
            string configurationPath = Path.Combine(appFolder, Constants.ConfigName);
            return configurationPath;
        }

        private string GetAppFolderPath()
        {
            string winAppDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolderPath = Path.Combine(winAppDir, Constants.AppName);
            return appFolderPath;
        }
    }
}
