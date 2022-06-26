using System;

namespace Omnishell.Core.Styles
{
    internal class RibbonFormatter : AbstractFormater
    {
        public override FormatedStyle Format(Style left, Style right, ConsoleString word)
        {
            return new FormatedStyle
            {
                Prefix = new ConsoleString()
                {
                    Foreground = HasNoNeighbour(left) ? word.Background : left.Background,
                    Background = HasNoNeighbour(left) ? ConsoleColor.Black : word.Background,
                    String = HasNoNeighbour(left) ? "" : ""
                },
                Center = word,
                Suffix = new ConsoleString()
                //Suffix = new ConsoleString()
                //{
                //    Foreground = word.Background,
                //    Background = HasNoNeighbour(right) ? ConsoleColor.Black : right.Background,
                //    String = ""
                //}
            };
        }

        private static bool HasNoNeighbour(Style style)
        {
            return (style == null || style.FormatType == FormatType.Clear);
        }
    }
}
