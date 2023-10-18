namespace Core.Segments;

public interface ISegmentRegistry
{
	AbstractSegment[] GetSegments(LinkedList<string> linkedOrder);
	void RegisterCustomSegments(Dictionary<string, string> segments);
}