using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Omnishell.Core.Units.Styles
{
    internal class StyleProviderTest
    {
        private Style StyleA;
        private Style StyleB;
        private Style StyleC;

        [Test]
        public void ShouldProvideCurrentStyle()
        {
            var profile = CreateProfile();
            var styleProvider = new StyleProvider(profile);
            var segment = new Mock<BaseSegment>();
            segment.Setup(s => s.Name).Returns("SegmentB");

            var styleB = styleProvider.GetStyle(segment.Object);
            var styleA = styleProvider.GetPreviousStyle(segment.Object);
            var styleC = styleProvider.GetNextStyle(segment.Object);

            Assert.That(styleB, Is.EqualTo(StyleB));
            Assert.That(styleA, Is.EqualTo(StyleA));
            Assert.That(styleC, Is.EqualTo(StyleC));
        }

        [Test]
        public void ShouldReturnDefaultOnEmptyProfile()
        {
            var profile = new Profile();
            var styleProvider = new StyleProvider(profile);
            var segment = new Mock<BaseSegment>();
            segment.Setup(s => s.Name).Returns("SegmentB");

            var styleB = styleProvider.GetStyle(segment.Object);
            var styleA = styleProvider.GetPreviousStyle(segment.Object);
            var styleC = styleProvider.GetNextStyle(segment.Object);

            Assert.That(styleB, Is.Not.Null);
            Assert.That(styleB.FormatType, Is.EqualTo(FormatType.Clear));
            Assert.That(styleA, Is.Not.Null);
            Assert.That(styleA.FormatType, Is.EqualTo(FormatType.Clear));
            Assert.That(styleC, Is.Not.Null);
            Assert.That(styleC.FormatType, Is.EqualTo(FormatType.Clear));
        }

        private Profile CreateProfile()
        {
            StyleA = new Style()
            {
                FormatType = FormatType.Clear,
                Foreground = ConsoleColor.Black,
                Background = ConsoleColor.DarkGray
            };
            StyleB = new Style()
            {
                FormatType = FormatType.Diamond,
                Foreground = ConsoleColor.Black,
                Background = ConsoleColor.DarkGray
            };
            StyleC = new Style()
            {
                FormatType = FormatType.Ribbon,
                Foreground = ConsoleColor.Black,
                Background = ConsoleColor.DarkGray
            };
            return new Profile()
            {
                Order = new string[] { "SegmentA", "SegmentB", "SegmentC" },
                Styles = new Dictionary<string, Style>
                {
                    {
                        "SegmentA", StyleA
                    },
                    {
                        "SegmentB", StyleB
                    },
                    {
                        "SegmentC", StyleC
                    }
                }
            };
        }
    }
}
