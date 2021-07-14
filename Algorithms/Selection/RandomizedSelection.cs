using System;
using Utilities;

namespace Algorithms.Selection
{
    public static class RandomizedSelectionAlgorithm
    {
        public static int QuickSelect(int[] array, int position)
        {
            return array.RandomizedSelectionRecursive(0, array.Length - 1, position);
        }

        public static int RandomizedSelectionRecursive(this int[] array, int start, int end, int position)
        {
            if (start == end) return array[start];
                            
            int partitionIndex = array.Partition(start, end);

            if(partitionIndex == position)
            {
                return array[partitionIndex];
            }
            else if( partitionIndex > position)
            {
                return array.RandomizedSelectionRecursive(start, partitionIndex - 1, position);
            }
            else
            {
                return array.RandomizedSelectionRecursive(partitionIndex + 1, end, position); 
            }
            
        }

        public static int Partition(this int[] array, int start, int end)
        {

            int pivotIndex = Helpers.GetRandomNumber(start, end + 1);

            int i = start + 1;
            int pivot = array[pivotIndex];

            array.Swap(start, pivotIndex);

            
            for (int j = start+1; j <= end; j++)
            {
                if (array[j] < pivot)
                {
                    array.Swap(i, j);
                    i++;
                }
            }

            array.Swap(start, i-1);
            return i - 1;
        }
    }
}
