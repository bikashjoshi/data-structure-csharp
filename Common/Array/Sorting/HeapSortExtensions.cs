using System;

namespace Common
{
    public static class HeapSortExtensions
    {
        public static void HeapSort<T>(this T[] array, bool isAscending = true) where T : IComparable<T>
        {
            Action<T[], int, int> heapify;
            Func<T, T, bool> comparor;
            if (isAscending)
            {
                // For Ascending, use Max Heap
                heapify = HeapExtensions.HeapifyMax;
                comparor = ComparerHelper.DescendingComparor;
            }
            else
            {
                // For Descnding, use Min Heap
                heapify = HeapExtensions.HeapifyMin;
                comparor = ComparerHelper.AscendingComparor;
            }

            // First create a heap from array input
            for (var index = array.Length / 2; index >= 0; index--) // optimizing instead of using with start index = array.Length - 1
            {
                heapify(array, index, array.Length - 1);
            }

            var lastIndex = array.Length - 1;
            for (var step = 1; step <= array.Length; step++)
            {
                if (comparor(array[0], array[lastIndex]))
                {
                    // swap the root
                    array.Swap(0, lastIndex);                    
                }                

                lastIndex--; // increment the sorted region on tail, and decrement the heap length
                heapify(array, 0, lastIndex);                
            }
        }
    }
}
