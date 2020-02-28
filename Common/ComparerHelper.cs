using System;

namespace Common
{
    internal class ComparerHelper
    {
        public static bool AscendingComparor<T>(T item1, T item2) where T : IComparable<T>
        {
            return item1.CompareTo(item2) < 0;
        }

        public static bool DescendingComparor<T>(T item1, T item2) where T : IComparable<T>
        {
            return item1.CompareTo(item2) > 0;
        }
    }
}
