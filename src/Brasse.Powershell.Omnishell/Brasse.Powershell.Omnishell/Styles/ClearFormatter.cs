using Omnishell.Core.Styles;
using System;

namespace Omnishell.Core
{
    internal class ClearFormatter : AbstractFormater
    {
        public override FormatedStyle Format(Style left, Style right, ConsoleString word)
        {
            return new FormatedStyle
            {
                Center = new ConsoleString
                {
                    Background = ConsoleColor.Black,
                    Foreground = word.Foreground,
                    String = word.String,
                }
            };
        }
    }
}