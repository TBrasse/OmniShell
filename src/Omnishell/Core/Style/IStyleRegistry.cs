namespace Core.Style
{
    public interface IStyleRegistry
    {
        IStyle GetStyle(string styleName);
    }
}