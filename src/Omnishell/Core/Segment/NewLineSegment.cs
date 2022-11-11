namespace Core.Segment
{
	public class NewLineSegment : ISegment
	{
		public string Name { get; set; } = "newLine";
		public Format Format { get; set; }
		public string Value { get; set; }
		public PaintedString Prefix { get; set; }
		public PaintedString Center { get; set; }
		public PaintedString Suffix { get; set; }

		public bool Resolve(IShellExecutor shell)
		{
			Value = "\n";
			return true;
		}
	}
}
