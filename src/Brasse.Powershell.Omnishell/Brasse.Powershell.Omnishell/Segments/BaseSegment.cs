namespace Omnishell.Core
{
	internal abstract class BaseSegment : IBaseSegment
	{
		public abstract string Name { get; }
		public abstract string[] Expressions { get; }
		public virtual string PromptExpression { get; }
	}
}
