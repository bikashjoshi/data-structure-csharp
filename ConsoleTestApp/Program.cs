using Common;
using ConsoleTestApp.specs;
using System;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {                   
            QueueSpecs.Validate<QueueUsingStack<int>>();            
            TreeTraversalSpecs.Validate<BinaryTree<int>>();
          
            PriorityQueueSpecs.RunSample();
            HeapSortSpecs.RunSample();
            TrieSpecs.RunSample();
            MergeTwoSortedArraySpecs.RunSample();

            Console.WriteLine(Environment.NewLine + "@@ Traversal depth first using recursion @@");
            RouterSpecs.PrintSample<RouterWithRecursionTraversal>();
            Console.WriteLine(Environment.NewLine + "@@ Traversal depth first using stack @@");
            RouterSpecs.PrintSample<RouterWithDepthFirstTraversal>();
            Console.WriteLine(Environment.NewLine + "@@ Traversal breadth first using queue @@");
            RouterSpecs.PrintSample<RouterWithBreadthFirstTraversal>();

            Console.WriteLine(Environment.NewLine + "Press any key to continue...");
            Console.ReadKey();
        }       
    }
}
