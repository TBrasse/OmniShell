﻿namespace Core.Shell;

public interface IShellExecutor
{
	PowershellResult Execute(string command);
}
