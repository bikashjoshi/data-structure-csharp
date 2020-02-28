using Common;
using System;
using System.Diagnostics;

namespace ConsoleTestApp.specs
{
    public static class QueueSpecs
    {
        public static void Validate<T>() where T : IQueue<int>,new()
        {
            Console.WriteLine(Environment.NewLine + "******************** RUNNING QUEUE VALIDATION ********************");
            var queue = new T();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(5);

            Debug.Assert(queue.Peek() == 1);
            
            Debug.Assert(queue.Count == 3);

            Debug.Assert(queue.Dequeue() == 1);
            queue.Enqueue(6);
            Debug.Assert(queue.Dequeue() == 2);
            Debug.Assert(queue.Peek() == 5);
            queue.Enqueue(7);
            queue.Enqueue(8);
            Debug.Assert(queue.Dequeue() == 5);

            Debug.Assert(queue.Count == 3);

            Console.WriteLine("******************** COMPLETED ********************");            
        }
    }
}
