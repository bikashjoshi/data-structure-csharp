using System;

namespace ConsoleTestApp.specs
{
    internal class MergeTwoSortedArraySpecs
    {
        public static void RunSample()
        {
            Console.WriteLine(Environment.NewLine + "******************** Merge two sorted array ********************");
            var array1 = new[] { 2, 4, 16, 21 };
            var array2 = new[] { 1, 2, 4, 5, 18 };

            var array = MergeTwoSortedArray.Merge(array1, array2);

            Console.WriteLine("Array1 => " + string.Join(", ", array1));
            Console.WriteLine("Array2 => " + string.Join(", ", array2));
            Console.WriteLine("Merged Array => " + string.Join(", ", array));
            Console.WriteLine(Environment.NewLine + "******************** COMPLETED ********************");
        }
    }
}
