using Moq;
using NUnit.Framework;
using Omnishell.Core.Segments;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Omnishell.Core.Units
{
    public class DateSegmentTest
    {
        [Test]
        public void ShouldReturnDate()
        {
            DateSegment segment = new DateSegment();

            IShell powershell = new Powershell();
            IFormatProvider formatProvider = new FormatProvider();
            IStyleProvider styleProvider = new StyleProvider(
                CreateProfile(),
                new Powershell()
            );

            var resolver = new SegmentResolver(powershell, formatProvider, styleProvider);

            var formatedStyle = resolver.Resolve(segment);
            Assert.IsTrue(
                DateTime.TryParseExact(
                    formatedStyle.Center.String,
                    "HH:mm:ss",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out _
                ),
                "ResolvedExpression is not a valid date format"
            );
        }

        private IConfigurationReader CreateProfile()
        {
            Mock<IConfigurationReader> configReaderMock = new Mock<IConfigurationReader>();
            configReaderMock.Setup(x => x.Read()).Returns
            (
                new Configuration
                {
                    Switch = "profile",
                    Profiles = new Dictionary<string, Profile>
                    {
                        {
                            "profile", new Profile()
                        }
                    }
                }
            );
            return configReaderMock.Object;
        }
    }
}