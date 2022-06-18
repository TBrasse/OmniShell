namespace Omnishell.Core
{
	internal interface IBaseSegment
	{
		string[] Expressions { get; }
		string Name { get; }
		string PromptExpression { get; }
	}
}