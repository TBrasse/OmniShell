using Omnishell.Core.Styles;

namespace Omnishell.Core
{
    internal interface IFormatProvider
    {
        AbstractFormater GetFormater(FormatType formatType);
    }
}