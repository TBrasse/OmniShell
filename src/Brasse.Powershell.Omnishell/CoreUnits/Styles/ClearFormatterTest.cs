using NUnit.Framework;
using Omnishell.Core.Styles;
using System;

namespace Omnishell.Core.Units.Styles
{
    internal class ClearFormatterTest
    {
        private AbstractFormater style = new ClearFormatter();

        [Test]
        public void ShouldHandleNullValuesOfNeighbour()
        {
            var format = style.Format(null, null, new ConsoleString()
            {
                Background = ConsoleColor.Cyan,
                Foreground = ConsoleColor.Red,
                String = "TestWord"
            });
            Assert.That(format.Prefix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Prefix.Foreground, Is.EqualTo(ConsoleColor.White));
            Assert.That(format.Prefix.String, Is.EqualTo(string.Empty));

            Assert.That(format.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Foreground, Is.EqualTo(ConsoleColor.Red));
            Assert.That(format.String, Is.EqualTo("TestWord"));

            Assert.That(format.Suffix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Suffix.Foreground, Is.EqualTo(ConsoleColor.White));
            Assert.That(format.Suffix.String, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ShouldCreateRibonStyleWithoutNeighbour()
        {
            var format = style.Format(
                new Style { FormatType = FormatType.Clear },
                new Style { FormatType = FormatType.Clear },
                new ConsoleString()
                {
                    Background = ConsoleColor.Cyan,
                    Foreground = ConsoleColor.Red,
                    String = "TestWord"
                }
            );
            Assert.That(format.Prefix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Prefix.Foreground, Is.EqualTo(ConsoleColor.White));
            Assert.That(format.Prefix.String, Is.EqualTo(string.Empty));

            Assert.That(format.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Foreground, Is.EqualTo(ConsoleColor.Red));
            Assert.That(format.String, Is.EqualTo("TestWord"));

            Assert.That(format.Suffix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Suffix.Foreground, Is.EqualTo(ConsoleColor.White));
            Assert.That(format.Suffix.String, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ShouldCreateRibonStyleWithLeftNeighbour()
        {
            var leftFormat = new Style()
            {
                Background = ConsoleColor.DarkGreen,
                Foreground = ConsoleColor.Yellow,
            };
            var format = style.Format(leftFormat, null, new ConsoleString()
            {
                Background = ConsoleColor.Cyan,
                Foreground = ConsoleColor.Red,
                String = "TestWord"
            });
            Assert.That(format.Prefix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Prefix.Foreground, Is.EqualTo(ConsoleColor.White));
            Assert.That(format.Prefix.String, Is.EqualTo(string.Empty));

            Assert.That(format.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Foreground, Is.EqualTo(ConsoleColor.Red));
            Assert.That(format.String, Is.EqualTo("TestWord"));

            Assert.That(format.Suffix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Suffix.Foreground, Is.EqualTo(ConsoleColor.White));
            Assert.That(format.Suffix.String, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ShouldCreateRibonStyleWithRightNeighbour()
        {
            var rightFormat = new Style()
            {
                Background = ConsoleColor.DarkGreen,
                Foreground = ConsoleColor.Yellow,
            };
            var format = style.Format(null, rightFormat, new ConsoleString()
            {
                Background = ConsoleColor.Cyan,
                Foreground = ConsoleColor.Red,
                String = "TestWord"
            });
            Assert.That(format.Prefix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Prefix.Foreground, Is.EqualTo(ConsoleColor.White));
            Assert.That(format.Prefix.String, Is.EqualTo(string.Empty));

            Assert.That(format.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Foreground, Is.EqualTo(ConsoleColor.Red));
            Assert.That(format.String, Is.EqualTo("TestWord"));

            Assert.That(format.Suffix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Suffix.Foreground, Is.EqualTo(ConsoleColor.White));
            Assert.That(format.Suffix.String, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ShouldCreateRibonStyleWithBothNeighbours()
        {
            var leftFormat = new Style()
            {
                Background = ConsoleColor.DarkGreen,
                Foreground = ConsoleColor.Yellow,
            };
            var rightFormat = new Style()
            {
                Background = ConsoleColor.DarkMagenta,
                Foreground = ConsoleColor.White,
            };
            var format = style.Format(leftFormat, rightFormat, new ConsoleString()
            {
                Background = ConsoleColor.Cyan,
                Foreground = ConsoleColor.Red,
                String = "TestWord"
            });
            Assert.That(format.Prefix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Prefix.Foreground, Is.EqualTo(ConsoleColor.White));
            Assert.That(format.Prefix.String, Is.EqualTo(string.Empty));

            Assert.That(format.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Foreground, Is.EqualTo(ConsoleColor.Red));
            Assert.That(format.String, Is.EqualTo("TestWord"));

            Assert.That(format.Suffix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Suffix.Foreground, Is.EqualTo(ConsoleColor.White));
            Assert.That(format.Suffix.String, Is.EqualTo(string.Empty));
        }
    }
}
