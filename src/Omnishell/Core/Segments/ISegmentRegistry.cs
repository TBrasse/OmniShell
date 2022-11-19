namespace Core.Segments;

public interface ISegmentRegistry
{
	AbstractSegment[] GetSegments(LinkedList<string> linkedOrder);
}