namespace Core.Style
{
    public class ClearStyle : IStyle
    {
        public string Name => "clear";

        public ISegment ApplyStyle
        (
            ISegment current,
            Format format,
            ISegment? previous,
            ISegment? next
        )
        {
            current.Prefix = new PaintedString();
            current.Center = new PaintedString
            {
                String = current.ResolvedValue
            };
            current.Suffix = new PaintedString();
            return current;
        }
    }
}
