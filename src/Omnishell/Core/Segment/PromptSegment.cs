namespace Core.Segment
{
	public class PromptSegment : ISegment
	{
		public string Name { get; set; } = "prompt";
		public string Expression { get; } = "echo '>'";
		public Format Format { get; set; }
		public string Value { get; set; }
		public PaintedString Prefix { get; set; }
		public PaintedString Center { get; set; }
		public PaintedString Suffix { get; set; }

		public bool Resolve(IShellExecutor shell)
		{
			PowershellResult result = shell.Execute(Expression);
			Value = result.Value;
			return result.Successfull && !string.IsNullOrEmpty(result.Value);
		}
	}
}
