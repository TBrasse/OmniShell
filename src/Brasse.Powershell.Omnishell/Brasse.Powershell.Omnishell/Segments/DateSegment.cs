namespace Omnishell.Core.Segments
{
    class DateSegment : BaseSegment
    {
        public override string Name => "date";
        public override string[] Expressions => new[] { @"Get-Date -Format ""HH:mm:ss""" };
    }
}
