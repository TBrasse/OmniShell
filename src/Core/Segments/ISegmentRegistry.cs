namespace Core.Segments;

public interface ISegmentRegistry
{
	void ReadAndSetSegments();
	void RegisterCustomSegments();
}