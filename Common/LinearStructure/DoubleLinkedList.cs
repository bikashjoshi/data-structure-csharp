namespace Common.LinearStructure
{
    public class DoubleLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public void Add(T item)
        {
            var node = new Node<T> { Value = item }; ;
            if (_head == null)
            {
                _head = node;
                _tail = _head;
                return;
            }

            _tail.Next = node;
            _tail = node;
        }

        public void Reverse()
        {
            var tail = _tail;
            _tail = Reverse(_head);
            _tail.Next = null;
            _head = tail;
        }

        private Node<T> Reverse(Node<T> node)
        {
            var next = node.Next;
            if (next == null)
            {
                return node;
            }

            var reverse = Reverse(next);
            reverse.Next = node;
            return node;
        }
    }
}
