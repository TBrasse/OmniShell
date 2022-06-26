using System.Linq;

namespace Omnishell.Core
{
    internal class StyleProvider : IStyleProvider
    {
        private readonly Profile _profile;

        public StyleProvider
        (
            IConfigurationReader configurationReader,
            IShell shell
        )
        {
            Configuration configuration = configurationReader.Read();
            string profileName = shell.Execute(configuration.Switch).First();
            _profile = configuration.Profiles[profileName];
        }

        public Style GetNextStyle(IBaseSegment segment)
        {
            var nextNode = _profile.LinkedOrder.Find(segment.Name)?.Next;
            if (nextNode == null) return new Style { FormatType = FormatType.Clear };
            return _profile.Styles[nextNode.Value];
        }

        public Style GetPreviousStyle(IBaseSegment segment)
        {
            var previousNode = _profile.LinkedOrder.Find(segment.Name)?.Previous;
            if (previousNode == null) return new Style { FormatType = FormatType.Clear };
            return _profile.Styles[previousNode.Value];
        }

        public Style GetStyle(IBaseSegment segment)
        {
            var styleExists = _profile.Styles.TryGetValue(segment.Name, out var style);
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