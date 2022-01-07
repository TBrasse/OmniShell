using Omnishell.Core.Styles;
using Omnishell.Core.Units;

namespace Omnishell.Core
{
    internal interface ISegmentResolver
    {
        public FormatedStyle Resolve(BaseSegment segment);
    }
}