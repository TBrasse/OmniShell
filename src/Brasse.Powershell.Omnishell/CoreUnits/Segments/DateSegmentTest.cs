using NUnit.Framework;
using Omnishell.Core.Segments;
using System;
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
            IStyleProvider styleProvider = new StyleProvider(new Profile());

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
    }
}