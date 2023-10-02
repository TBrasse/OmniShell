namespace Core.Styles;

public interface IStyleRegistry
{
	IStyle GetStyle(string styleName);
}