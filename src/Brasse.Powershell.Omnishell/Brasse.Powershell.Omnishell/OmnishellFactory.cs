using System;

namespace Omnishell.Core
{
    internal class OmnishellFactory
    {
        public static IOmnishell GetOmnishell()
        {
            return Omnishell.GetOmnishell(Setup.Services);
        }
    }
}
