using Common;
using System.Collections.Generic;

namespace ConsoleTestApp
{
    internal class QueueUsingStack<T> : IQueue<T>    
    {
        private readonly Stack<T> _firstStack = new Stack<T>();
        private readonly Stack<T> _secondStack = new Stack<T>();

        public int Count { get; private set; }

        public T Dequeue()
        {
            if (_secondStack.Count > 0)
            {
                Count--;
                return _secondStack.Pop();
            }

            while (_firstStack.Count > 0)
            {
                _secondStack.Push(_firstStack.Pop());
            }

            Count--;
            return _secondStack.Pop();
        }

        public void Enqueue(T t)
        {
            Count++;
            _firstStack.Push(t);
        }

        public T Peek()
        {
            if (_secondStack.Count > 0)
            {
                return _secondStack.Peek();
            }

            while (_firstStack.Count > 0)
            {
                _secondStack.Push(_firstStack.Pop());
            }

            return _secondStack.Peek();
        }
    }
}
