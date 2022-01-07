using NUnit.Framework;
using Omnishell.Core.Styles;
using System;

namespace Omnishell.Core.Units.Styles
{
    internal class FormatProviderTest
    {
        [Test]
        public void ShouldHandleAllFormatTypeEnums()
        {
            var formatProvider = new FormatProvider();
            foreach(var formatType in Enum.GetValues<FormatType>())
            {
                Assert.DoesNotThrow(() =>
                {
                    var formater = formatProvider.GetFormater(formatType);
                    Assert.That(formater, Is.Not.Null);
                });
            }
        }
    }
}
