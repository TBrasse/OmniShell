using Moq;
using NUnit.Framework;
using System;
using Omnishell.Core.Styles;
using System.Collections.Generic;

namespace Omnishell.Core.Units
{
    internal class SegmentResolverTest
    {
        [Test]
        public void ShouldResolveExpressionSegment()
        {
            var testExpressions = new[] { "echo test" };

            var formatProvider = new FormatProvider();
            var styleProvider = new StyleProvider(CreateProfile());

            var segment = new Mock<BaseSegment>();
            segment.Setup(s => s.Name).Returns("test");
            segment.Setup(s => s.Expressions).Returns(testExpressions);

            var powershellMock = new Mock<IShell>();
            powershellMock.Setup(p => p.Execute(segment.Object)).Returns(new[]
            {
                "t","e","s","t"
            });

            ISegmentResolver resolver = new SegmentResolver(powershellMock.Object, formatProvider, styleProvider);
            FormatedStyle resolvedStyle = resolver.Resolve(segment.Object);

            Assert.That(resolvedStyle.Prefix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(resolvedStyle.Prefix.Foreground, Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(resolvedStyle.Prefix.String, Is.EqualTo(""));

            Assert.That(resolvedStyle.Background, Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(resolvedStyle.Foreground, Is.EqualTo(ConsoleColor.Gray));
            Assert.That(resolvedStyle.String, Is.EqualTo("test"));

            Assert.That(resolvedStyle.Suffix.Background, Is.EqualTo(ConsoleColor.Black));
            Assert.That(resolvedStyle.Suffix.Foreground, Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(resolvedStyle.Suffix.String, Is.EqualTo(""));
        }

        private Profile CreateProfile()
        {
            return new Profile()
            {
                Order = new string[] { "test" },
                Styles = new Dictionary<string, Style>
                {
                    {
                        "test", new Style()
                        {
                            FormatType = FormatType.Ribbon,
                            Foreground = ConsoleColor.Gray,
                            Background = ConsoleColor.DarkGray
                        }
                    }
                }
            };
        }
    }
}
