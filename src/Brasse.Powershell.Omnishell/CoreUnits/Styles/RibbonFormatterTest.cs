using NUnit.Framework;
using Omnishell.Core.Styles;
using System;

namespace Omnishell.Core.Units.Styles
{
    internal class RibbonFormatterTest
    {
        private AbstractFormater style = new RibbonFormatter();

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
            Assert.That(format.Prefix.Foreground, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Prefix.String, Is.EqualTo(""));

            Assert.That(format.Background, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Foreground, Is.EqualTo(ConsoleColor.Red));
            Assert.That(format.String, Is.EqualTo("TestWord"));

            Assert.That(format.Suffix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Suffix.Foreground, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Suffix.String, Is.EqualTo(""));
        }

        [Test]
        public void ShouldCreateRibonStyleWithoutNeighbour()
        {
            var format = style.Format(
                new Style { FormatType = FormatType.Clear},
                new Style { FormatType = FormatType.Clear},
                new ConsoleString()
                {
                    Background = ConsoleColor.Cyan,
                    Foreground = ConsoleColor.Red,
                    String = "TestWord"
                }
            );
            Assert.That(format.Prefix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Prefix.Foreground, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Prefix.String, Is.EqualTo(""));

            Assert.That(format.Background, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Foreground, Is.EqualTo(ConsoleColor.Red));
            Assert.That(format.String, Is.EqualTo("TestWord"));

            Assert.That(format.Suffix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Suffix.Foreground, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Suffix.String, Is.EqualTo(""));
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
            Assert.That(format.Prefix.Background, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Prefix.Foreground, Is.EqualTo(ConsoleColor.DarkGreen));
            Assert.That(format.Prefix.String, Is.EqualTo(""));

            Assert.That(format.Background, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Foreground, Is.EqualTo(ConsoleColor.Red));
            Assert.That(format.String, Is.EqualTo("TestWord"));

            Assert.That(format.Suffix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(format.Suffix.Foreground, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Suffix.String, Is.EqualTo(""));
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
            Assert.That(format.Prefix.Foreground, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Prefix.String, Is.EqualTo(""));

            Assert.That(format.Background, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Foreground, Is.EqualTo(ConsoleColor.Red));
            Assert.That(format.String, Is.EqualTo("TestWord"));

            Assert.That(format.Suffix.Background, Is.EqualTo(ConsoleColor.DarkGreen));
            Assert.That(format.Suffix.Foreground, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Suffix.String, Is.EqualTo(""));
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
            Assert.That(format.Prefix.Background, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Prefix.Foreground, Is.EqualTo(ConsoleColor.DarkGreen));
            Assert.That(format.Prefix.String, Is.EqualTo(""));
            Assert.That(format.Background, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Foreground, Is.EqualTo(ConsoleColor.Red));
            Assert.That(format.String, Is.EqualTo("TestWord"));
            Assert.That(format.Suffix.Background, Is.EqualTo(ConsoleColor.DarkMagenta));
            Assert.That(format.Suffix.Foreground, Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(format.Suffix.String, Is.EqualTo(""));
        }
    }
}
