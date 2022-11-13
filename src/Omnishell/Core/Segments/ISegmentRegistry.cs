namespace Core.Segments;

public interface ISegmentRegistry
{
	ISegment[] GetSegments(LinkedList<string> linkedOrder);
}