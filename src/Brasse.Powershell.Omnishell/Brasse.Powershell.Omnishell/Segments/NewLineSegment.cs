namespace Omnishell.Core.Segments
{
    class NewLineSegment : BaseSegment
    {
        public override string Name => "newLine";
        public override string[] Expressions => new[] {
            "echo `n"
        };
    }
}
