using NUnit.Framework;
using System;
using System.IO;

namespace Omnishell.Core.Units
{
    public class TestPaths
    {
        private IPaths sut = new Paths();

        [Test]
        public void ShouldReturnConfigurationFolder()
        {
            string winAppDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appDir = Path.Combine(winAppDir,Constants.AppName);
            string path = sut.GetAppFolder();
            Assert.AreEqual(path, appDir);
        }

        [Test]
        public void ShouldReturnConfigurationPath()
        {
            var appDir = sut.GetAppFolder();
            string expectedPath = Path.Combine(appDir, Constants.ConfigName);
            var path = sut.GetConfigurationPath();
            Assert.AreEqual(path,expectedPath);
        }
    }
}