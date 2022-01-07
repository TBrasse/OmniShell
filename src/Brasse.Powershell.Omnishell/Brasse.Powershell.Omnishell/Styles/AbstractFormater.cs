namespace Omnishell.Core.Styles
{
    internal abstract class AbstractFormater
    {
        public abstract FormatedStyle Format(Style left, Style right, ConsoleString word);
    }
}