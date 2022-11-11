namespace Core.Segment
{
	public interface ISegment
	{
		string Name { get; set; }
		Format Format { get; set; }
		string Value { get; set; }
		PaintedString Prefix { get; set; }
		PaintedString Center { get; set; }
		PaintedString Suffix { get; set; }
		bool Resolve(IShellExecutor shell);
	}
}