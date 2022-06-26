using NUnit.Framework;
using System;
using System.IO;

namespace Omnishell.Core.Units
{
    public class TestOmnishell
    {
        [Test]
        public void ShouldWork()
        {
            IOmnishell omnishell = Omnishell.GetOmnishell(TestSetup.Services);
            omnishell.PrintPrompt();
        }
    }
}