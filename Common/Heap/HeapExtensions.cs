using System;

namespace Common
{
    internal static class HeapExtensions
    {
        public static void HeapifyMin<T>(this T[] array, int parentIndex, int lastIndex) where T : IComparable<T>
        {
            Heapify(array, parentIndex, lastIndex, ComparerHelper.AscendingComparor);
        }

        public static void HeapifyMax<T>(this T[] array, int parentIndex, int lastIndex) where T : IComparable<T>
        {
            Heapify(array, parentIndex, lastIndex, ComparerHelper.DescendingComparor);
        }

        public static void Heapify<T>(this T[] array, int parentIndex, int lastIndex, Func<T, T, bool> comparor) where T : IComparable<T>
        {
            var childIndex = GetHeapLeftChildIndex(parentIndex);
            if (childIndex <= lastIndex)
            {
                int rightChildIndex = childIndex + 1;
                if (rightChildIndex <= lastIndex && comparor(array[rightChildIndex], array[childIndex]))
                {
                    childIndex = rightChildIndex;
                }

                if (comparor(array[childIndex], array[parentIndex]))
                {
                    array.Swap(parentIndex, childIndex);
                    Heapify(array, childIndex, lastIndex, comparor);
                }
            }
        }

        public static void TrickleUpMin<T>(this T[] array, int currentIndex) where T : IComparable<T>
        {
            TrickleUp(array, currentIndex, ComparerHelper.AscendingComparor);
        }

        public static void TrickleUpMax<T>(this T[] array, int currentIndex) where T : IComparable<T>
        {
            TrickleUp(array, currentIndex, ComparerHelper.DescendingComparor);
        }

        public static void TrickleUp<T>(this T[] array, int currentIndex, Func<T, T, bool> comparor) where T : IComparable<T>
        {
            int parentIndex = GetHeapParentIndex(currentIndex);
            while (parentIndex >= 0 && comparor(array[currentIndex], array[parentIndex]))
            {
                array.Swap(parentIndex, currentIndex);
                currentIndex = parentIndex;
                parentIndex = GetHeapParentIndex(currentIndex);
            }
        }

        public static int GetHeapParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        public static int GetHeapLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }
    }
}
