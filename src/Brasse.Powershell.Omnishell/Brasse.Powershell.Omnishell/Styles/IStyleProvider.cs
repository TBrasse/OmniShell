namespace Omnishell.Core
{
    internal interface IStyleProvider
    {
        Style GetStyle(IBaseSegment segment);
        Style GetPreviousStyle(IBaseSegment segment);
        Style GetNextStyle(IBaseSegment segment);
    }
}