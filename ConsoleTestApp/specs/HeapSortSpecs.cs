using Common;
using System;

namespace ConsoleTestApp.specs
{
    internal class HeapSortSpecs
    {
        public static void RunSample()
        {
            Console.WriteLine(Environment.NewLine + "******************** Heap Sort ********************");
            var array = new int[] { 3, 7, 4, 1, 10, 5, 20, 11, 3, 10, 6, 2 };
            Console.WriteLine($"Initial =>{array.CommaSeparatedArray()}");
            array.HeapSort(true);
            Console.WriteLine($"Final =>{array.CommaSeparatedArray()}");
            Console.WriteLine("***************** COMPLETED *************************");
        }
    }
}
