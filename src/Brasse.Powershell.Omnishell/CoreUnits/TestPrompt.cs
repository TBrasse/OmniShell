using NUnit.Framework;

namespace Omnishell.Core.Units
{
    public class TestPrompt
    {
        [Test]
        public void ShouldReturnBasicPrompt()
        {
            string prompt = Prompt.GetPrompt();
            StringAssert.Contains(prompt, "\n> ");
        }
    }
}