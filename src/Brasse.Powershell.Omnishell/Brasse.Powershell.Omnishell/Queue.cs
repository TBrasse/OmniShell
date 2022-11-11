using System.Collections.Concurrent;

namespace Omnishell.Core
{
    internal class Queue<T> : IQueue<T>
    {
        private ConcurrentQueue<T> _queue;

        public Queue()
        {
            _queue = new ConcurrentQueue<T>();
        }

        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
        }

        public (bool, T) Dequeue()
        {
            bool success = _queue.TryDequeue(out T item);
            return (success, item);
        }

        public int Count
        {
            get { return _queue.Count; }
        }
    }
}