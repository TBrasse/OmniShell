using System;

namespace Omnishell.Core
{
    internal class Style
    {
        public FormatType FormatType { get; set; }
        public ConsoleColor Foreground { get; set; }
        public ConsoleColor Background { get; set; }
    }
}