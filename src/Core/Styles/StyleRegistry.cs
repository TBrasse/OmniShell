namespace Core.Styles;

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
		_registeredStyles.TryGetValue(styleName, out IStyle? style);
		if (style == null)
		{
			return new ClearStyle();
		}
		return _registeredStyles[styleName];
	}
}
