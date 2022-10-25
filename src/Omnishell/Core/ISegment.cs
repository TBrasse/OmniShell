namespace Core
{
    public interface ISegment
    {
        string Name { get; set; }
        string[] Expressions { get; set; }
        string ResolvedValue { get; set; }
        PaintedString Prefix { get; set; }
        PaintedString Center { get; set; }
        PaintedString Suffix { get; set; }
    }
}