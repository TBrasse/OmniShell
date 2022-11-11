using Core.Segment;

public interface ISegmentRegistry
{
	ISegment[] GetSegments(LinkedList<string> linkedOrder);
}