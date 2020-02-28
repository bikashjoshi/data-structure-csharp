using System;
using System.Collections.Generic;

namespace Common
{
    public static class LinearSearchExtensions
    {
        public static int LinearSearch<T>(this T[] items, Func<T, bool> predicate, int? startIndex = null, int? endIndex = null, bool startReverse = false)
        {
            return LinearFind(items, false, predicate, startIndex, endIndex, startReverse)[0];
        }

        public static IEnumerable<int> LinearFindAll<T>(this T[] items, Func<T, bool> predicate, int? startIndex = null, int? endIndex = null, bool startReverse = false)
        {
            return LinearFind(items, true, predicate, startIndex, endIndex, startReverse);
        }

        public static IList<int> LinearFind<T>(this T[] items, bool findall, Func<T, bool> predicate, int? startIndex = null, int? endIndex = null, bool startReverse = false)
        {
            var allIndexes = new List<int>();

            if (!startReverse)
            {
                if (startIndex == null)
                    startIndex = 0;
                if (endIndex == null)
                    endIndex = items.Length - 1;

                for (int i = startIndex.Value; i <= endIndex.Value; i++)
                {
                    var item = items[i];
                    if (predicate(item))
                    {
                        allIndexes.Add(i);
                        if (!findall)
                            break;
                    }
                }

                return allIndexes;
            }
            else
            {
                if (startIndex == null)
                    startIndex = items.Length - 1;
                if (endIndex == null)
                    endIndex = 0;
                for (int i = startIndex.Value; i >= endIndex.Value; i--)
                {
                    var item = items[i];
                    if (predicate(item))
                    {
                        allIndexes.Add(i);
                        if (!findall)
                            break;
                    }
                }

                return allIndexes;
            }
        }
    }
}
