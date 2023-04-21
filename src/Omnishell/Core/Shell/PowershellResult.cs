namespace Core.Shell;

public class ShellResult
{
	public bool Successfull { get; init; }
	public string Value { get; init; } = string.Empty;
	public string Error { get; init; } = string.Empty;

	internal static ShellResult Failed(string errorMessage)
	{
		return new ShellResult
		{
			Successfull = false,
			Error = errorMessage
		};
	}

	internal static ShellResult Succeed(string result)
	{
		return new ShellResult
		{
			Successfull = true,
			Value = result
		};
	}
}
