public class PowershellResult
{
	public bool Successfull { get; init; }
	public string Value { get; init; } = string.Empty;
	public string Error { get; init; } = string.Empty;

	internal static PowershellResult Failed(string errorMessage)
	{
		return new PowershellResult
		{
			Successfull = false,
			Error = errorMessage
		};
	}

	internal static PowershellResult Succeed(string result)
	{
		return new PowershellResult
		{
			Successfull = true,
			Value = result
		};
	}
}