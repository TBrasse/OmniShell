using System;

namespace Omnishell.Core.Styles
{
    internal class FormatedStyle
    {
        public FormatedStyle()
        {
            Prefix = new ConsoleString();
            Center = new ConsoleString();
            Suffix = new ConsoleString();
        }

        public ConsoleString Prefix { get; internal set; }
        public ConsoleString Center { get; internal set; }
        public ConsoleString Suffix { get; internal set; }
        public ConsoleColor Background => Center.Background;
        public ConsoleColor Foreground => Center.Foreground;
        public string String => Center.String;
    }
}
