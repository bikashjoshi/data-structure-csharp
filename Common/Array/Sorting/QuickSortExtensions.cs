using System;

namespace Common
{
    public static class QuickSortExtensions
    {
        public static void QuickSort<T>(this T[] array, bool isAscending = true) where T : IComparable<T>
        {
            if (isAscending)
                QuickSorting(array, 0, array.Length - 1, ComparerHelper.AscendingComparor);
            else
                QuickSorting(array, 0, array.Length - 1, ComparerHelper.DescendingComparor);
        }

        private static void QuickSorting<T>(T[] array, int low, int high, Func<T, T, bool> comparor) where T : IComparable<T>
        {
            if (low < high)
            {
                int partitionIndex = QuickSortParitioning(array, low, high, comparor);
                var str = string.Join(", ", array);
                QuickSorting(array, low, partitionIndex - 1, comparor);
                QuickSorting(array, partitionIndex + 1, high, comparor);
            }
        }

        internal static int QuickSortParitioning<T>(this T[] array, int low, int high, Func<T, T, bool> comparor) where T : IComparable<T>
        {
            T pivot = array[low];
            int index = low;
            for (int j = low + 1; j <= high; j++)
            {
                if (comparor(array[j], pivot))
                {
                    index++;
                    array.Swap(index, j);                    
                }
            }

            var partitionIndex = index;
            array.Swap(partitionIndex, low);
            return partitionIndex;
        }
    }
}
