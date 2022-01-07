using System;

namespace Omnishell.Core.Styles
{
    internal class DiamondFormatter : AbstractFormater
    {
        public override FormatedStyle Format(Style left, Style right, ConsoleString word)
        {
            return new FormatedStyle
            {
                Prefix = new ConsoleString()
                {
                    Foreground = word.Background,
                    Background = ConsoleColor.Black,
                    String = ""
                },
                Center = word,
                Suffix = new ConsoleString()
                {
                    Foreground = word.Background,
                    Background = ConsoleColor.Black,
                    String = ""
                }
            };
        }
    }
}
