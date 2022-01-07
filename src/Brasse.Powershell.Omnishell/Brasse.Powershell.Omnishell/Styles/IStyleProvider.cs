namespace Omnishell.Core
{
    internal interface IStyleProvider
    {
        Style GetStyle(BaseSegment segment);
        Style GetPreviousStyle(BaseSegment segment);
        Style GetNextStyle(BaseSegment segment);
    }
}