using System;
namespace Omnishell.Core.Styles
{
    internal class ConsoleString
    {
        public ConsoleString()
        {
            Background = ConsoleColor.Black;
            Foreground = ConsoleColor.White;
            String = string.Empty;
        }

        public ConsoleColor Background { get; internal set; }
        public ConsoleColor Foreground { get; internal set; }
        public string String { get; internal set; }
    }
}
