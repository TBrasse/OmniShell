namespace Core.Segment
{
	public class DateSegment : ISegment
	{
		public string Name { get; set; } = "date";
		public string Expression { get; } = "Get-Date -Format HH:mm:ss";
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
