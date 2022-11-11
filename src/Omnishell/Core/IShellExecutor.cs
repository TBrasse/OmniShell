namespace Core
{
	public interface IShellExecutor
	{
		PowershellResult Execute(string command);
	}
}
