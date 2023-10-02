using Core.Segments;
using Core.Shell;

namespace Core.Resolver;

public class SegmentResolver : ISegmentResolver
{
	private readonly IShellExecutor _shell;

	public SegmentResolver
	(
		IShellExecutor shell
	)
	{
		_shell = shell;
	}

	public (AbstractSegment[], string[]) ResolveSegments(AbstractSegment[] orderedSegments)
	{
		List<AbstractSegment> resolvedHeaderSegments = new List<AbstractSegment>();
		List<string> resolvedPromptSegments = new List<string>();
		foreach (AbstractSegment segment in orderedSegments)
		{
			bool shouldPrint = segment.Resolve(_shell);
			if (shouldPrint)
			{
				if (segment.IsPrompt)
				{
					resolvedPromptSegments.Add(segment.Value);
				}
				else
				{
					resolvedHeaderSegments.Add(segment);
				}
			}
		}
		return (resolvedHeaderSegments.ToArray(), resolvedPromptSegments.ToArray());
	}
}
