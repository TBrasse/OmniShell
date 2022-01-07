using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Omnishell.Core.Units
{
    public class TestConfiguration
    {
        [Test, Order(1)]
        public void ShouldSerializeConfiguration()
        {
            Assert.DoesNotThrow(() =>
            {
                Configuration.Serialize(CreateConfiguration());
            });
        }

        [Test, Order(2)]
        public void ShouldReadConfiguration()
        {
            Configuration configuration = null;
            var serializedJson = Configuration.Serialize(CreateConfiguration());
            Assert.DoesNotThrow(() =>
            {
                configuration = Configuration.Deserialize(serializedJson);
            });
            Assert.NotNull(configuration);
            Assert.That(configuration.Version, Is.EqualTo("0.0.1"));
            Assert.That(configuration.Switch, Is.EqualTo("echo test"));
            Assert.That(configuration.Profiles, Is.Not.Empty);
            Assert.That(configuration.Profiles["test"], Is.TypeOf<Profile>());
            Assert.That(configuration.Profiles["test"].Order, Is.Not.Empty);
            Assert.That(configuration.Profiles["test"].Styles["test"], Is.TypeOf<Style>());
            Assert.That(configuration.Profiles["test"].Styles["test"].FormatType, Is.EqualTo(FormatType.Clear));
            Assert.That(configuration.Profiles["test"].Styles["test"].Foreground, Is.EqualTo(ConsoleColor.Black));
            Assert.That(configuration.Profiles["test"].Styles["test"].Background, Is.EqualTo(ConsoleColor.DarkGray));
        }

        private Configuration CreateConfiguration()
        {
            return new Configuration()
            {
                Version = "0.0.1",
                Switch = "echo test",
                Profiles = new Dictionary<string, Profile> {
                    {
                        "test", new Profile()
                        {
                            Order = new string[] { "test" },
                            Styles = new Dictionary<string, Style> {
                                {
                                    "test", new Style()
                                    {
                                        FormatType = FormatType.Clear,
                                        Foreground = ConsoleColor.Black,
                                        Background = ConsoleColor.DarkGray
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}