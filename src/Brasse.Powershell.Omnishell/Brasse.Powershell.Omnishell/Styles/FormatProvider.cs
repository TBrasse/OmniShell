using Omnishell.Core.Styles;
using System;

namespace Omnishell.Core
{
    internal class FormatProvider : IFormatProvider
    {
        private readonly Lazy<RibbonFormatter> ribbonFormater = new Lazy<RibbonFormatter>();
        private readonly Lazy<ClearFormatter> clearFormater = new Lazy<ClearFormatter>();
        private readonly Lazy<DiamondFormatter> diamondFormater = new Lazy<DiamondFormatter>();

        public AbstractFormater GetFormater(FormatType formatType)
        {
            switch (formatType)
            {
                case FormatType.Ribbon: return ribbonFormater.Value;
                case FormatType.Clear: return clearFormater.Value;
                case FormatType.Diamond: return diamondFormater.Value;
                default: throw new NotSupportedException($"Format type: {formatType} is not supported");
            }
        }
    }
}