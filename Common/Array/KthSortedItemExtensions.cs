using System;

namespace Common
{
    public static class KthSortedItemExtensions
    {
        public static T KthHighest<T>(this T[] array, int k) where T : IComparable<T>
        {
            return KthSortedItem(array, k, 0, array.Length - 1, ComparerHelper.DescendingComparor);
        }

        public static T KthLowest<T>(this T[] array, int k) where T : IComparable<T>
        {
            return KthSortedItem(array, k, 0, array.Length - 1, ComparerHelper.AscendingComparor);
        }

        private static T KthSortedItem<T>(T[] array, int k, int first, int last, Func<T, T, bool> comparor) where T : IComparable<T>
        {
            var pivot = array[first];
            var pivotIndex = array.QuickSortParitioning(first, last, comparor);
            if (k < pivotIndex - first + 1)
            {
                // item should be left of pivot index, so only check s1 section
                return KthSortedItem(array, k, first, pivotIndex - 1, comparor);
            }
            else if (k == pivotIndex - first + 1)
            {
                // pivot is the kth largest or highest element
                return pivot;
            }
            else
            {
                // item should be on right side of pivot index, so check s2 section
                return KthSortedItem(array, k - (pivotIndex - first + 1), pivotIndex + 1, last, comparor);
            }
        }
    }
}
