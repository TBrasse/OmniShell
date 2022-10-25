namespace Core
{
    public class PathSegment : ISegment
    {
        public string Name { get; set; } = "path";
        public string[] Expressions { get; set; } = new string[] { "pwd" };
        public string ResolvedValue { get; set; }
        public PaintedString Prefix { get; set; }
        public PaintedString Center { get; set; }
        public PaintedString Suffix { get; set; }
    }
}