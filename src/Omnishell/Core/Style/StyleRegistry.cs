namespace Core.Style
{
    public class StyleRegistry : IStyleRegistry
    {
        private readonly Dictionary<string, IStyle> _registeredStyles;

        public StyleRegistry
        (
            IEnumerable<IStyle> styles
        )
        {
            _registeredStyles = new Dictionary<string, IStyle>();
            foreach (IStyle style in styles)
            {
                _registeredStyles[style.Name] = style;
            }
        }

        public IStyle GetStyle(string styleName)
        {
            //todo: fix not registred styles
            return _registeredStyles[styleName];
        }
    }
}
