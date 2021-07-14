using System;
using Utilities;

namespace Algorithms.Sorting
{
    public class QuickSort
    {
        public enum Mode
        {
            First, Last, Middle, Random
        }

        public static long comparisonCount = 0;
        private int[] array;
        private Mode mode;

        public QuickSort(Mode Mode, int[] A)
        {
            array = A;
            mode = Mode;
            comparisonCount = 0;
        }

        public void Sort(int start, int end)
        {
            if (end - start == 1)
            {
                // Base case, no recursive calls. 2 Element, just sort them.
                if (array[start] > array[end])
                {
                    array.Swap(start, end);
                }

                comparisonCount++;
            }
            else if (end <= start)
            {
                // Base case: only one element
            }
            else
            {

                int pivotIndex;
                switch (this.mode)
                {
                    case Mode.First:
                        pivotIndex = GetFirstElementAsPivot(start, end);
                        break;
                    case Mode.Last:
                        pivotIndex = GetLastElementAsPivot(start, end);
                        break;
                    case Mode.Middle:
                        pivotIndex = GetMedianOfThreeAsPivot(start, end);
                        break;
                    case Mode.Random:
                        pivotIndex = GetRandomElementAsPivot(start, end);
                        break;
                    default:
                        throw new Exception();
                }
                int partitionIndex = Partition(start, end, pivotIndex);
                Sort(start, partitionIndex - 1);
                Sort(partitionIndex + 1, end);
            }
        }

        public int Partition(int start, int end, int pivotIndex)
        {

            // Update comparisonsCount
            comparisonCount += (long)(end - start);

            // Partition
            int i = start;
            int pivot = array[pivotIndex];

            for (int j = start; j <= end; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    array.Swap(i, j);
                }
            }

            // Put pivot into correct position
            array.Swap(i, pivotIndex);

            return i;
        }

        

        public int GetFirstElementAsPivot(int start, int end)
        {
            return start;
        }

        public int GetLastElementAsPivot(int start, int end)
        {

            array.Swap(start, end);
            return start;
        }

        public int GetMedianOfThreeAsPivot(int start, int end)
        {

            int pivotIndex = -1;

            int mid = ((end - start) / 2) + start;
            int[] b = new int[3];
            b[0] = array[start];
            b[1] = array[mid];
            b[2] = array[end];

            Array.Sort(b);
            if (b[1] == array[start])
            {
                pivotIndex = start;
            }
            else if (b[1] == array[mid])
            {
                pivotIndex = mid;
            }
            else
            {
                pivotIndex = end;
            }

            // Move pivot to start index.
            array.Swap(start, pivotIndex);

            return start;
        }

        public int GetRandomElementAsPivot(int start, int end)
        {
            int pivotIndex = Helpers.GetRandomNumber(start, end);

            array.Swap(start, pivotIndex);

            return start;
        }

        

    }
}
