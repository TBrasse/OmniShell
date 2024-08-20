using Core.Utils;

namespace Core.Segments;

public class SegmentRegistry : ISegmentRegistry
{
	private readonly Dictionary<string, AbstractSegment> _segmentsRegistry;
	private readonly IObjectRepository _objectRepository;

	public SegmentRegistry
	(
		IEnumerable<AbstractSegment> segments,
		IObjectRepository objectRepository
	)
	{
		_segmentsRegistry = new Dictionary<string, AbstractSegment>();
		foreach (AbstractSegment segment in segments)
		{
			_segmentsRegistry.Add(segment.Name, segment);
		}
		_objectRepository = objectRepository;
	}

	public void GetSegments()
	{
		List<AbstractSegment> segments = new List<AbstractSegment>();
		foreach (string segmentName in _objectRepository.Profile.LinkedOrder)
		{
			if (_segmentsRegistry.ContainsKey(segmentName))
				segments.Add(_segmentsRegistry[segmentName]);
		}
		_objectRepository.OrderedSegments = segments.ToArray();
	}

	public void RegisterCustomSegments()
	{
		foreach (string segmentName in _objectRepository.Profile.Segments.Keys)
		{
			if (!_segmentsRegistry.ContainsKey(segmentName))
			{
				_segmentsRegistry[segmentName] = new CustomSegment(segmentName, _objectRepository.Profile.Segments[segmentName]);
			}
			else if (_segmentsRegistry[segmentName] is CustomSegment)
			{
				((CustomSegment)_segmentsRegistry[segmentName]).Expression = _objectRepository.Profile.Segments[segmentName];
			}
		}
	}
}
