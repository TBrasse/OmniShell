using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Omnishell.Core.Units
{
    public class TestConfigurationFile
    {
        [Test]
        public void ShouldReadConfiguration()
        {
            string configJson = @"{""Version"":""0.0.0""}";

            IPaths paths = new Paths();
            var fileMoq = new Mock<IFile>();
            fileMoq.Setup(f => f.ReadAllText(paths.GetConfigurationPath()))
                .Returns(configJson);

            var sut = new ConfigurationReader(fileMoq.Object, paths);
            Configuration configuration = sut.Read();
            Assert.AreEqual(configuration.Version, "0.0.0");
        }

        [Test]
        public void ShouldWriteConfiguration()
        {
            IPaths paths = new Paths();
            Configuration configuration = new Configuration()
            {
                Version = "0.0.1",
                Switch = "test",
                Profiles = new Dictionary<string, Profile>()
            };
            string configJson = @"{""Version"":""0.0.1"",""Switch"":""test"",""Profiles"":{}}";
            var fileMoq = new Mock<IFile>();
            fileMoq.Setup(f => f.WriteAllText(paths.GetConfigurationPath(), configJson));

            var sut = new ConfigurationWriter(fileMoq.Object, paths);
            sut.Write(configuration);

            fileMoq.Verify(f => f.WriteAllText(paths.GetConfigurationPath(), configJson));

        }
    }
}