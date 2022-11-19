namespace Omnishell.Core
{
    internal interface IQueue<T>
    {
        int Count { get; }

        (bool, T) Dequeue();

        void Enqueue(T item);
    }
}