namespace Core.Shell;

public interface IShellExecutor
{
	ShellResult Execute(string command, bool withNewLine = false);
}
