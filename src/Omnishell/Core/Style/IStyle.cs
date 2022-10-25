namespace Core.Style
{
    public interface IStyle
    {
        string Name { get; }

        ISegment ApplyStyle(ISegment current, Format format, ISegment? previous, ISegment? next);
    }
}