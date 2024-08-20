using Core.Segments;
using Core.Shell;
using Core.Utils;

namespace Core.Resolver;

public class SegmentResolver : ISegmentResolver
{
	private readonly IShellExecutor _shell;
	private readonly IObjectRepository _objectRepository;

	public SegmentResolver
	(
		IShellExecutor shell,
		IObjectRepository objectRepository
	)
	{
		_shell = shell;
		_objectRepository = objectRepository;
	}

	public void ResolveSegments()
	{
		List<AbstractSegment> resolvedHeaderSegments = new List<AbstractSegment>();
		List<string> resolvedPromptSegments = new List<string>();
		foreach (AbstractSegment segment in _objectRepository.OrderedSegments)
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
		_objectRepository.ResolvedRepository = resolvedHeaderSegments.ToArray();
		_objectRepository.Prompt = string.Join("", resolvedPromptSegments);
	}
}
