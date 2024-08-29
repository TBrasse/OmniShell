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

	public void ReadAndSetSegments()
	{
		List<AbstractSegment> segments = new List<AbstractSegment>();
		var linkedOrder = _objectRepository.Profile.LinkedOrder;
		foreach (string segmentName in linkedOrder)
		{
			if (_segmentsRegistry.ContainsKey(segmentName))
				segments.Add(_segmentsRegistry[segmentName]);
		}
		_objectRepository.OrderedSegments = segments.ToArray();
	}

	public void RegisterCustomSegments()
	{
		var segments = _objectRepository.Profile.Segments;
		foreach (string segmentName in segments.Keys)
		{
			if (!_segmentsRegistry.ContainsKey(segmentName))
			{
				_segmentsRegistry[segmentName] = new CustomSegment(segmentName, segments[segmentName]);
			}
			else if (_segmentsRegistry[segmentName] is CustomSegment)
			{
				((CustomSegment)_segmentsRegistry[segmentName]).Expression = segments[segmentName];
			}
		}
	}
}
