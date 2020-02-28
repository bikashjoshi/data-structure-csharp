namespace Common
{
    public interface IQueue<T>
    {
        void Enqueue(T t);

        T Dequeue();

        T Peek();

        int Count { get; }
    }
}
