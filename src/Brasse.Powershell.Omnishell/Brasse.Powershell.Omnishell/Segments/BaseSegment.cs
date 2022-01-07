namespace Omnishell.Core
{
    internal abstract class BaseSegment
    {
        public abstract string Name { get; }
        public abstract string[] Expressions { get; }
        public virtual string PromptExpression { get; }
    }
}
