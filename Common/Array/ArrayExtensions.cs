namespace Common
{
    public static class Extensions
    {
        public static string CommaSeparatedArray<T>(this T[] items)
        {
            return string.Join(", ", items);
        }       
      
        public static void Swap<T>(this T[] array, int i, int j)
        {
            if (i == j)
                return;

            T temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }       
    }
}
