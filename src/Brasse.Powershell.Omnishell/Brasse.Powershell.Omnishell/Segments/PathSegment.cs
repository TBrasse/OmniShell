namespace Omnishell.Core.Segments
{
    class PathSegment : BaseSegment
    {
        public override string Name => "path";
        public override string[] Expressions => new[] {
            "$executionContext.SessionState.Path.CurrentLocation.Path"
        };
    }
}
