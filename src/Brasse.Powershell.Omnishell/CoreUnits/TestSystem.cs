using NUnit.Framework;
using System.Runtime.InteropServices;

namespace Omnishell.Core.Units
{
    public class TestSystem
    {
        [Test]
        public void ShouldBeWindows()
        {
            Assert.True(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));
        }

        [Test]
        public void ShouldBeLinux()
        {
            Assert.True(RuntimeInformation.IsOSPlatform(OSPlatform.Linux));
        }
    }
}