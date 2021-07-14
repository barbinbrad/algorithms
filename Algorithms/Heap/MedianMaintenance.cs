using System;
using System.Collections.Generic;
using Algorithms.Heap;

namespace Algorithms.Heap
{
    public class HeapSort
    {
        public static int MaintainMedian(ref MinHeap<int> high, ref MaxHeap<int> low, int next)
        {
            int median;

            if(low.Count >= high.Count)
                median = (low.Count == 0) ? 0 : low.GetExtreme();
            else
                median = (high.Count == 0) ? 0 : high.GetExtreme();
            
            if(next > median)
            {
                if (high.Count > low.Count)
                {
                    int replacement = high.RemoveExtreme();
                    low.Insert(replacement);
                }

                high.Insert(next);
            }
                
            else
            {
                if (low.Count > high.Count)
                {
                    int replacement = low.RemoveExtreme();
                    high.Insert(replacement);
                }

                low.Insert(next);
            }
                
            
            return (low.Count >= high.Count) ? low.GetExtreme() : high.GetExtreme();
        }


    }
}
