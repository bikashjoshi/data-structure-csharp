namespace Common
{
    internal class QueueArrayBased<T> : IQueue<T>
    {
        private int Max_Queue = 10;
        private T[] _array;
        private int _front, _back;

        public QueueArrayBased()
        {
            _front = 0;
            _back = Max_Queue - 1;
            Count = 0;
            _array = new T[Max_Queue];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            var item = _array[_front];
            Count--;
            _front = (_front + 1) % Max_Queue;
            return item;
        }

        public void Enqueue(T t)
        {
            _back = (_back + 1) % Max_Queue;
            _array[_back] = t;
            Count++;
        }

        public T Peek()
        {
            return _array[_front];
        }
    }
}
