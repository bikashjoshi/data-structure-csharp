using System;

namespace Common
{
    public static class BinarySearchExtensions
    {
        public static int BinaryFindOne<T>(this T[] items, T item, bool sortedAscending = true) where T : IComparable<T>
        {
            if (items == null)
                return -1;

            int leftIndex = 0;
            int rightIndex = items.Length - 1;
            if (sortedAscending)
            {
                while (leftIndex <= rightIndex)
                {
                    int mid = (leftIndex + rightIndex) >> 1;

                    if (items[mid].CompareTo(item) == 0)
                    {
                        return mid;
                    }
                    else if (items[mid].CompareTo(item) > 0)
                    {
                        rightIndex = mid - 1; ;
                    }
                    else
                    {
                        leftIndex = mid + 1;
                    }
                }
            }
            else
            {
                while (leftIndex <= rightIndex)
                {
                    int mid = (leftIndex + rightIndex) >> 1;

                    if (items[mid].CompareTo(item) == 0)
                    {
                        return mid;
                    }
                    else if (items[mid].CompareTo(item) < 0)
                    {
                        rightIndex = mid - 1; ;
                    }
                    else
                    {
                        leftIndex = mid + 1;
                    }
                }
            }

            return -1;
        }
    }
}
