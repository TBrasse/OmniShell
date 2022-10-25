using Core;

namespace Console
{
    internal class ConsolePrinter : ISegmentPrinter
    {
        public void Print(ISegment[] paintedSegments)
        {
            foreach (ISegment segment in paintedSegments)
            {
                System.Console.Write(segment.Prefix.String);
                System.Console.Write(segment.Center.String);
                System.Console.Write(segment.Suffix.String);
            }
        }
    }
}
