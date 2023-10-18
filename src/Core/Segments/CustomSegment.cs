using Core.Shell;

namespace Core.Segments
{
	internal class CustomSegment : AbstractSegment
	{
		public CustomSegment(string name, string expression)
		{
			Name = name;
			Expression = expression;
		}

		public string Expression { get; internal set; }

		public override bool Resolve(IShellExecutor shell)
		{
			PowershellResult result = shell.Execute(Expression);
			Value = result.Value;
			return result.Successfull && !string.IsNullOrEmpty(result.Value);
		}
	}
}