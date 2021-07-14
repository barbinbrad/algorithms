using System;
namespace Algorithms.Counting
{
    public class CountInversions
    {
        public static long MergeSortAndCount(ref int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];
            
            if (array.Length <= 1) return 0;

            int midPoint = array.Length / 2;

            left = new int[midPoint];
            right = (array.Length % 2 == 0) ? new int[midPoint] :  new int[midPoint + 1];


            for (int i = 0; i < midPoint; i++)
            {
                left[i] = array[i];
            }
               
            int k = 0;
            
            for (int i = midPoint; i < array.Length; i++)
            {
                right[k] = array[i];
                k++;
            }

            long x = MergeSortAndCount(ref left);
            long y = MergeSortAndCount(ref right);
            long z = MergeAndCount(ref array, left, right);

            return x + y + z;
        }

        public static long MergeAndCount(ref int[] array, int[] left, int[] right)
        {
            long count = 0;
            int resultLength = right.Length + left.Length;
            array = new int[resultLength];

            int indexLeft = 0,
                indexRight = 0,
                indexResult = 0;

            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight])
                    {
                        array[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        array[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                        count += (left.Length - indexLeft);
                    }
                }
                else if (indexLeft < left.Length)
                {
                    array[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                    
                }
                else if (indexRight < right.Length)
                {
                    array[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            
            return count;
        }
    }
}
