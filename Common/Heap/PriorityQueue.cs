using System;

namespace Common
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly T[] _items;
        private int nextIndex = 0;
        private readonly int _maxSize;

        private readonly Action<T[], int, int> _heapify;
        private readonly Action<T[], int> _trickleUp;

        public int Size { get { return nextIndex; } }

        public bool IsEmpty { get { return nextIndex == 0; } }

        public PriorityQueue(int size, bool useMin = false)
        {
            _items = new T[size];
            _maxSize = size;
            if (useMin)
            {
                _heapify = HeapExtensions.HeapifyMin;
                _trickleUp = HeapExtensions.TrickleUpMin;
            }
            else
            {
                _heapify = HeapExtensions.HeapifyMax;
                _trickleUp = HeapExtensions.TrickleUpMax;
            }
        }

        public void Insert(T item)
        {
            if (Size > _maxSize)
            {
                throw new ArgumentOutOfRangeException("Cannot add further items.");
            }

            _items[nextIndex++] = item;
            int currentIndex = Size - 1;
            _trickleUp(_items, currentIndex);
        }

        public T Peek()
        {
            return _items[0];
        }

        public T Delete()
        {
            if (IsEmpty)
            {
                return default(T);
            }

            var root = _items[0];
            _items[0] = _items[Size - 1];
            nextIndex--;
            _heapify(_items, 0, Size - 1);
            return root;
        }
    }
}
