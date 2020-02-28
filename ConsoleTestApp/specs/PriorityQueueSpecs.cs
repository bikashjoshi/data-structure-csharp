using Common;
using System;

namespace ConsoleTestApp.specs
{
    internal class PriorityQueueSpecs
    {
        public static void RunSample()
        {
            Console.WriteLine(Environment.NewLine + "******************** RUNNING SAMPLE PRIORITY QUEUE ********************");
            var priorityQueue = new PriorityQueue<int>(15);
            priorityQueue.Insert(3);
            priorityQueue.Insert(7);
            priorityQueue.Insert(4);
            priorityQueue.Insert(1);
            priorityQueue.Insert(10);
            priorityQueue.Insert(5);
            priorityQueue.Insert(20);
            priorityQueue.Insert(11);
            priorityQueue.Insert(3);
            priorityQueue.Insert(10);
            priorityQueue.Insert(6);
            priorityQueue.Insert(2);

            while (!priorityQueue.IsEmpty)
            {
                Console.Write("{0}, ", priorityQueue.Delete());
            }

            Console.WriteLine("\r\n");

            priorityQueue = new PriorityQueue<int>(15, true);
            priorityQueue.Insert(3);
            priorityQueue.Insert(7);
            priorityQueue.Insert(4);
            priorityQueue.Insert(1);
            priorityQueue.Insert(10);
            priorityQueue.Insert(5);
            priorityQueue.Insert(20);
            priorityQueue.Insert(11);
            priorityQueue.Insert(3);
            priorityQueue.Insert(10);
            priorityQueue.Insert(6);
            priorityQueue.Insert(2);

            while (!priorityQueue.IsEmpty)
            {
                Console.Write("{0}, ", priorityQueue.Delete());
            }

            Console.WriteLine(Environment.NewLine + "******************** COMPLETED ********************");
        }
    }
}
