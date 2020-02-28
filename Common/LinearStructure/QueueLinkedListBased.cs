namespace Common
{
    internal class LinkedListBasedQueue<T> : IQueue<T>
    {
        private Node<T> _last = null; // the tail of the queue

        public int Count { get; private set; }

        public T Dequeue()
        {
            /* Structure is circular linked list
             * tail's Next points to the first item in queue
             */
            var node = _last.Next;
            if (node == _last)
                _last = null; // if node.next and node are same, queue is empty
            else
                _last.Next = node.Next; // tail's next now should point to next item in queue
            Count--;
            return node.Value;
        }

        public void Enqueue(T t)
        {
            var node = new Node<T> { Value = t };

            /* Structure is circular linked list
             * tail of the queue (i.e. _last.Next) 
             * should point to the first item in the queue.*/

            if (_last == null)
            {
                node.Next = node;
            }
            else
            {
                // newly added node should point to the first item
                node.Next = _last.Next;
                // previously added node should now point to new item
                _last.Next = node;
            }

            // tail node should be newly added node
            _last = node;
            Count++;
        }

        public T Peek()
        {
            return _last.Next.Value;
        }
    }
}
