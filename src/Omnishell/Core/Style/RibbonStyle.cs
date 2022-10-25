using Core;

namespace Core.Style
{
    public class RibbonStyle : IStyle
    {
        public string Name => "ribbon";

        public ISegment ApplyStyle
        (
            ISegment current, 
            Format format,
            ISegment? previous,
            ISegment? next
        )
        {
            current.Prefix = new PaintedString
            {
                Background = Exists(previous) ? current.Center.Background : ConsoleColor.Black,
                Foreground = Exists(previous) ? previous.Suffix.Background : current.Center.Foreground,
                String = Exists(previous) ? "" : ""
            };
            current.Center = new PaintedString
            {
                String = current.ResolvedValue
            };
            current.Suffix = new PaintedString
            {

            };
            return current;
        }

        private static bool Exists(ISegment? previous)
        {
            return !string.IsNullOrEmpty(previous?.Suffix?.String);
        }
    }
}
