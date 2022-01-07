using Omnishell.Core.Styles;
using System.Collections.Generic;

namespace Omnishell.Core
{
    internal class SegmentResolver : ISegmentResolver
    {
        private readonly IShell shell;
        private readonly IFormatProvider formatProvider;
        private readonly IStyleProvider styleProvider;

        public SegmentResolver(IShell shell, IFormatProvider formatProvider, IStyleProvider styleProvider)
        {
            this.shell = shell;
            this.formatProvider = formatProvider;
            this.styleProvider = styleProvider;
        }

        public FormatedStyle Resolve(BaseSegment segment)
        {
            IEnumerable<string> result = shell.Execute(segment);
            var segmentStyle = styleProvider.GetStyle(segment);
            var previousStyle = styleProvider.GetPreviousStyle(segment);
            var nextStyle = styleProvider.GetNextStyle(segment);
            AbstractFormater formater = formatProvider.GetFormater(segmentStyle.FormatType);
            return formater.Format(previousStyle, nextStyle, new ConsoleString()
            {
                Background = segmentStyle.Background,
                Foreground = segmentStyle.Foreground,
                String = string.Join("", result)
            });
        }
    }
}