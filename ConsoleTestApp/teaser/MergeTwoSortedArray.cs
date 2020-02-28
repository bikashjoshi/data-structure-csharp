
namespace ConsoleTestApp
{
    internal class MergeTwoSortedArray
    {         
        public static int[] Merge(int[] array1, int[] array2)
        {
            var array = new int[array1.Length + array2.Length];
            var i = 0;
            var j = 0;
            var k = 0;

            while (i < array1.Length && j < array2.Length && k < array.Length)
            {
                if (array1[i] < array2[j])
                {
                    array[k++] = array1[i++];
                }
                else
                {
                    array[k++] = array2[j++];
                }
            }

            if (k < array.Length)
            {
                // there may still left on either array1 or array2
                while (i < array1.Length)
                {
                    array[k++] = array1[i++];
                }

                while (j < array2.Length)
                {
                    array[k++] = array2[j++];
                }
            }

            return array;
        }
    }
}
