using Core.Shell;
using System.Text.RegularExpressions;

namespace Core.Segments;

public class GitSegment : AbstractSegment
{
	private string _expression { get; } = "git status -s";
	public IPSSettingProvider _settings { get; }

	public GitSegment(IPSSettingProvider settings)
	{
		Name = "git";
		_settings = settings;
	}

	public override bool Resolve(IShellExecutor shell)
	{
		var result = IsGitBranch();
		if (result.Success)
		{
			Value = GetBranchName(result.GitPath);
			PowershellResult rawStatusResult = shell.Execute(_expression, true);
			if (!string.IsNullOrEmpty(rawStatusResult.Value))
			{
				ParsGitFiles(rawStatusResult);
			}
			return rawStatusResult.Successfull;
		}
		return false;
	}

	private string GetBranchName(string gitPath)
	{
		string HeadPath = $"{gitPath}{Path.DirectorySeparatorChar}HEAD";
		string rawBranchName = File.OpenText(HeadPath).ReadToEnd();
		Match match = Regex.Match(rawBranchName, @".*refs\/heads\/(?<branch>.*)");
		return match.Groups["branch"].Value;
	}

	private (bool Success, string GitPath) IsGitBranch()
	{
		string path = _settings.WorkingDirectory;
		string pathRoot = Path.GetPathRoot(path) ?? throw new InvalidOperationException($"Path not rooted: {path}");
		char pathSeparator = Path.DirectorySeparatorChar;

		string testPath;
		do
		{
			testPath = Path.GetFullPath($"{path}{pathSeparator}");
			string gitPath = $"{testPath}.git";
			if (!Path.Exists(gitPath))
			{
				path += $"{pathSeparator}..";
			}
			else
			{
				return (true, gitPath);
			}
		}
		while (testPath != pathRoot);
		return (false, String.Empty);
	}

	private void ParsGitFiles(PowershellResult rawStatusResult)
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
