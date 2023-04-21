using Core.Shell;

namespace Core.Segments;

public class GitSegment : AbstractSegment
{
	private string[] _expressions { get; } = new[] {
		"git branch --show-current",
		"git status -s"
	};

	public override string Name => "git";

	public override bool Resolve(IShellExecutor shell)
	{
		ShellResult branchResult = shell.Execute(_expressions[0]);
		if (!branchResult.Value.StartsWith("fatal:"))
		{
			Value = branchResult.Value;
			ShellResult rawStatusResult = shell.Execute(_expressions[1], true);
			if (!string.IsNullOrEmpty(rawStatusResult.Value))
			{
				ParsGitFiles(rawStatusResult);
			}
		}
		return branchResult.Successfull && !string.IsNullOrEmpty(branchResult.Value);
	}

	private void ParsGitFiles(ShellResult rawStatusResult)
	{
		string[] lines = rawStatusResult.Value.Split("\r\n");
		//.Where(x => !string.IsNullOrEmpty(x))
		//.Select(x => x.Trim().Split(' ')[0]);
		int added = 0, modified = 0, deleted = 0, untracked = 0, unknown = 0;
		foreach (string line in lines)
		{
			if (!string.IsNullOrEmpty(line))
			{
				string label = line.Trim().Split(' ')[0];
				switch (label)
				{
					case "A": added++; break;
					case "D": deleted++; break;
					case "M": modified++; break;
					case "??": untracked++; break;
					default: unknown++; break;
				}
			}
		}
		if (added > 0)
		{
			Value += $" A{added}";
		}
		if (deleted > 0)
		{
			Value += $" D{deleted}";
		}
		if (modified > 0)
		{
			Value += $" M{modified}";
		}
		if (untracked > 0)
		{
			Value += $" U{untracked}";
		}
		if (unknown > 0)
		{
			Value += $" ?{unknown}";
		}
	}
}
