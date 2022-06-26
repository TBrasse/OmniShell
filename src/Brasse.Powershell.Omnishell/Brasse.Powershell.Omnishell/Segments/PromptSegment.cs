namespace Omnishell.Core.Segments
{
    class PromptSegment : BaseSegment
    {
        public override string Name => "prompt";
        public override string[] Expressions => new[] {
            "echo '>'"
        };
    }
}
