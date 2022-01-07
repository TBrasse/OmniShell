using System;

namespace Omnishell.Core
{
    internal class TestOmnishellFactory
    {
        public static IOmnishell GetOmnishell()
        {
            return Omnishell.GetOmnishell(TestSetup.Services);
        }
    }
}
