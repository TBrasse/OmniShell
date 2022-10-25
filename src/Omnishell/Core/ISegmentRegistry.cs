using Core;

public interface ISegmentRegistry
{
    ISegment[] GetSegments(LinkedList<string> linkedOrder);
}