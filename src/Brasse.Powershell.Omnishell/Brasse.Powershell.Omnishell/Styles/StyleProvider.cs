namespace Omnishell.Core
{
    internal class StyleProvider : IStyleProvider
    {
        private readonly Profile profile;

        public StyleProvider(Profile profile)
        {
            this.profile = profile;
        }

        public Style GetNextStyle(BaseSegment segment)
        {
            var nextNode = profile.LinkedOrder.Find(segment.Name)?.Next;
            if (nextNode == null) return new Style { FormatType = FormatType.Clear };
            return profile.Styles[nextNode.Value];
        }

        public Style GetPreviousStyle(BaseSegment segment)
        {
            var previousNode = profile.LinkedOrder.Find(segment.Name)?.Previous;
            if (previousNode == null) return new Style { FormatType = FormatType.Clear };
            return profile.Styles[previousNode.Value];
        }

        public Style GetStyle(BaseSegment segment)
        {
            var styleExists = profile.Styles.TryGetValue(segment.Name, out var style);
            if (styleExists)
            {
                return style;
            }
            else
            {
                return new Style { FormatType = FormatType.Clear };
            }
        }
    }
}