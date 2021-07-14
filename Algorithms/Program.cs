using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using Utilities;
using Algorithms.Selection;
using Algorithms.Sorting;
using Algorithms.Counting;
using Algorithms.Matrix;
using Algorithms.Geometry;
using Algorithms.Graph;
using Algorithms.Heap;
using Algorithms.Trees;


namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Merge Sort */

            int[] unsorted = Helpers.GetArrayOfRandomNumbers(0, 255, 8);
            int[] sorted = MergeSortAlgorithm.MergeSort(unsorted);

            foreach (int number in sorted)
            {
                Console.WriteLine(number.ToString());
            }

            /* Count Inversions */

            // int[] input = { 1, 3, 5, 2, 4, 6 };
            // int[] input = { 1, 2, 3, 4, 5, 6 };
            //int[] input = { 7, 6, 5, 4, 3, 2, 1 };
            //int output = CountInversions.MergeSortAndCount(ref input);

            //Console.WriteLine(output);

            /* Matrix Multiplication */
            //int[,] A = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            //int[,] B = new int[,] { { 7, 8 }, { 9, 10 }, { 11, 12 } };

            //int[,] C = MatrixMultiplication.BruteForce(A, B);

            //int[,] A = new int[,] { { 1, 2, 3, 4 },
            //                        { 5, 6, 7, 8 },
            //                        { 9, 10, 11, 12 },
            //                        { 13, 14, 15, 16 }
            //                      };
            //int[,] B = new int[,] { { 1, 2, 3, 4 },
            //                        { 5, 6, 7, 8 },
            //                        { 9, 10, 11, 12 },
            //                        { 13, 14, 15, 16 }
            //                      };

            //int[,] C = new int[,] { { 1, 1 },
            //                        { 1, 1 }
            //                      };

            //int[,] D = new int[,] { { 0, 0 },
            //                        { 0, 1 }
            //                      };

            //int[,] X = MatrixMultiplication.BruteForce(A, B);
            //int[,] Y = MatrixMultiplication.StrassenMultiplication(A, B);

            //int rows = Y.GetLength(0);
            //int columns = Y.GetLength(1);

            //for(int i = 0; i<rows; i++)
            //{
            //    for(int j=0; j<columns; j++)
            //    {
            //        Console.Write(X[i, j]);
            //        Console.Write("\t");
            //    }
            //    Console.Write("\n");
            //    Console.Write("\n");
            //}


            //Console.WriteLine("Strassen");
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < columns; j++)
            //    {
            //        Console.Write(Y[i, j]);
            //        Console.Write("\t");
            //    }
            //    Console.Write("\n");
            //    Console.Write("\n");
            //}

            /* Closest Pair */

            //Vector2[] Input =
            //{
            //    new Vector2(4,99),
            //    new Vector2(10,10),
            //    new Vector2(1,1),
            //    new Vector2(2,3),
            //    new Vector2(7,0),
            //    new Vector2(15,15),
            //    new Vector2(5,13),
            //    new Vector2(3,1),
            //    new Vector2(9,9)
            //};

            //Vector2[] Output = ClosestPair.ClosestPairsIn2D(Input);

            //Console.WriteLine(String.Format("The closest pair is ({0},{1}) and ({2},{3})", Output[0].X, Output[0].Y, Output[1].X, Output[1].Y));

            /* Homework 1 Programming Assignment */

            //string[] lines = System.IO.File.ReadAllLines(@"../../../../../Data/homework1.txt");
            //List<int> input = new List<int>();

            //foreach (string line in lines)
            //{
            //    input.Add(Convert.ToInt32(line));
            //}

            //int[] inputArray = input.ToArray();

            //long output = CountInversions.MergeSortAndCount(ref inputArray);

            //Console.WriteLine(output);

            /* Homework 2 QuickSort */

            //int count = 1000;
            // long comparisons = 0;
            //int[] input = Helpers.GetArrayOfRandomNumbers(0, 255, count);
            //int[] inputArray = Helpers.GetArrayOfNumbersFromFile(@"../../../../../Data/homework2.txt");

            //QuickSort quickSortFirst = new QuickSort(QuickSort.Mode.First, inputArray);
            //quickSortFirst.Sort(0, inputArray.Length - 1);
            //Console.WriteLine("Number of comparisons in first: " + QuickSort.comparisonCount);

            //QuickSort quickSortLast = new QuickSort(QuickSort.Mode.Last, inputArray);
            //quickSortLast.Sort(0, inputArray.Length - 1);
            //Console.WriteLine("Number of comparisons in last: " + QuickSort.comparisonCount);

            //QuickSort quickSortMiddle = new QuickSort(QuickSort.Mode.Middle, inputArray);
            //quickSortMiddle.Sort(0, inputArray.Length - 1);
            //Console.WriteLine("Number of comparisons in median: " + QuickSort.comparisonCount);

            //QuickSort quickSortRandom = new QuickSort(QuickSort.Mode.Random, inputArray);
            //quickSortRandom.Sort(0, inputArray.Length - 1);
            //Console.WriteLine("Number of comparisons in random: " + QuickSort.comparisonCount);

            /* Randomized Selection */

            //int[] input = Helpers.GetArrayOfRandomNumbers(0, 255, 20);
            //int[] input = Helpers.GetArrayOfShuffledNumbersWithinRange(1, 20);
            //int[] input = Helpers.GetArrayOfNumbersFromFile(@"../../../../../Data/homework2.txt");
            //int output = RandomizedSelectionAlgorithm.QuickSelect(input, 1234);


            /* Homework 3 Minimum Cuts */
            //string graphInput = @"../../../../../Data/homework3.txt";
            //char inputDelimeter = '\t';

            //var graph = Graphs.CreateUnweightedGraphFromDelimitedFile(graphInput, inputDelimeter);
            //var nodes = Graphs.GetNodes(graph);

            //int minimum = nodes.Count * (nodes.Count - 1);
            //int iterations = nodes.Count * nodes.Count * Convert.ToInt32(Math.Log((double)nodes.Count));


            //for (int i = 0; i < iterations + 1; i++)
            //{
            //    int observedMinimum = Graphs.MinimumCuts(graph, nodes);
            //    Console.WriteLine("Observed minimum on observation {0} is {1}", i, observedMinimum);

            //    if (observedMinimum < minimum) minimum = observedMinimum;

            //    graph = Graphs.CreateUnweightedGraphFromDelimitedFile(graphInput, inputDelimeter);
            //    nodes = Graphs.GetNodes(graph);

            //}

            //Console.WriteLine("Minimum cuts observed over {0} iterations is {1}", iterations, minimum);


            /* Breadth First Search */
            // string graphInput = @"../../../../../Data/homework3.txt";
            // char inputDelimeter = '\t';

            // var graph = Graphs.CreateUnweightedGraphFromDelimitedFile(graphInput, inputDelimeter);
            // int jumps = Graphs.BreadthFirstSearchShortestPath(graph, 42, 196);
            // var network = Graphs.BreadthFirstSearchConnectivity(graph);
            // bool isConnected = network.Count == 1;

            /* Depth First Search */
            // string graphInput = @"../../../../../Data/homework3.txt";
            // char inputDelimeter = '\t';

            // var graph = Graphs.CreateUnweightedGraphFromDelimitedFile(graphInput, inputDelimeter);
            // var nodes = Graphs.GetNodesWithProperties(graph);

            // var traversal = Graphs.DepthFirstSearchTraversalList(ref nodes, 1);

            /* Topological Sort */
            //string graphInput = @"../../../../../Data/acyclic-graph.txt";
            //char inputDelimeter = '\t';

            //var graph = Graphs.CreateUnweightedGraphFromDelimitedFile(graphInput, inputDelimeter);
            //var topologicalSort = Graphs.DepthFirstSearchTopologicalSort(graph);


            /* SCCs */

            // string graphInput = @"../../../../../Data/homework4.txt";
            // string fileOutput = @"../../../../../Data/homework4-results.txt";
            // char inputDelimeter = ' ';

            // var graph = Graphs.CreateUnweightedGraphFromDelimitedFile(graphInput, inputDelimeter);
            // Graphs.FindStronglyConnectedComponents(ref graph, fileOutput);

            // string[] lines = System.IO.File.ReadAllLines(fileOutput);
            // List<int> input = new List<int>();

            // foreach (string line in lines)
            // {
            //    input.Add(Convert.ToInt32(line));
            // }

            // int[] inputArray = input.ToArray();

            // int[] sorted = MergeSortAlgorithm.MergeSort(inputArray);
            // int first = sorted[inputArray.Length - 1];
            // int second = sorted[inputArray.Length - 2];
            // int third = sorted[inputArray.Length - 3];
            // int fourth = sorted[inputArray.Length - 4];
            // int fifth = sorted[inputArray.Length - 5];


            /* Dijkstra's Shortest Path */
            //var graph = Graphs.CreatedWeightedGraphFromDelimitedFile(@"../../../../../Data/homework5.txt", '\t');
            //Graphs.DijkstrasShortestPath(ref graph, 1);

            //var test = 7;
            //Graphs.LogDijkstraPath(graph, test);

            //test = 37;
            //Graphs.LogDijkstraPath(graph, test);

            //test = 59;
            //Graphs.LogDijkstraPath(graph, test);

            //test = 82;
            //Graphs.LogDijkstraPath(graph, test);

            //test = 99;
            //Graphs.LogDijkstraPath(graph, test);

            //test = 115;
            //Graphs.LogDijkstraPath(graph, test);

            //test = 133;
            //Graphs.LogDijkstraPath(graph, test);

            //test = 165;
            //Graphs.LogDijkstraPath(graph, test);

            //test = 188;
            //Graphs.LogDijkstraPath(graph, test);

            //test = 197;
            //Graphs.LogDijkstraPath(graph, test);

            /* Heaps - Median Maintenance */

            //var high = new MaxHeap<int>();
            //var low = new MinHeap<int>();
            //int median;

            //median = HeapSort.MaintainMedian(ref high, ref low, 4);
            //median = HeapSort.MaintainMedian(ref high, ref low, 1);
            //median = HeapSort.MaintainMedian(ref high, ref low, 2);
            //median = HeapSort.MaintainMedian(ref high, ref low, 1);
            //median = HeapSort.MaintainMedian(ref high, ref low, 1);
            //median = HeapSort.MaintainMedian(ref high, ref low, 23);
            //median = HeapSort.MaintainMedian(ref high, ref low, 87);
            //median = HeapSort.MaintainMedian(ref high, ref low, 3);

            /* Binary Trees */

            //var input = Helpers.GetArrayOfRandomNumbers(0, 255);
            //var input = Helpers.GetArrayOfOrderedNumbers(5, 1);
            //var tree = new BinarySearchTree();

            //foreach (int number in input)
            //{
            //    tree.Add(number);
            //}



            //var sortedList = tree.ToList(tree.Root);

            //var minimum = tree.Min();
            //var maximum = tree.Max();


            //var search = tree.Search(tree.Root, minimum.Value);

            //bool passed = (search != null);

            //tree.Remove(minimum.Value);

            //var newMinimum = tree.Min();

            //passed = (minimum.Value != newMinimum.Value);

            ///* Homework 6.1 */
            //string[] lines = System.IO.File.ReadAllLines(@"../../../../../Data/homework6-1.txt");
            //var input = new Dictionary<long, long>();
            //var uniqueTs = new Dictionary<long, long>();
            //long current = 0;
            //long solutions = 0;
            //long lowRange = -10000;
            //long highRange = 10000;

            //Console.WriteLine("Parsing input from file");

            //foreach (string line in lines)
            //{
            //    long value = Convert.ToInt64(line);
            //    try
            //    {
            //        input.Add(value, value);                   
            //    }
            //    catch
            //    {
            //        // Console.WriteLine("Found duplicate value: {0}", value);
            //    }

            //    if (current % 10000 == 0)
            //        Console.Write("\r{0}%   ", current / 10000);

            //    current++;
            //}

            
            //Console.WriteLine("\nFound {0} unique values in the data", input.Count);
            //Console.WriteLine("\nSearching for unique sums between -10,000 and 10,000");

            //current = 0;

            //foreach (var entry in input)
            //{
            //    for(long i = lowRange; i < highRange + 1; i++)
            //    {
            //        long target = i - entry.Value;
            //        long total = entry.Value + target;
            //        if (input.ContainsKey(target))
                        
            //            if (!uniqueTs.ContainsKey(total))
            //            {
            //                try
            //                {
            //                    uniqueTs.Add(total, total);
            //                    solutions++;
            //                }
            //                catch
            //                {

            //                }
            //            }
                        
            //    }

            //    if (current % 10000 == 0)
            //        Console.Write("\r{0}%   ", current / 10000);

            //    current++;
            //}

            //Console.WriteLine("\nFound {0} unique T values", solutions);
            //Console.WriteLine("\nDouble check: {0}", uniqueTs.Count);

            ///* Homework 6.2 */
            //string[] lines = System.IO.File.ReadAllLines(@"../../../../../Data/homework6-2.txt");

            //var high = new MinHeap<int>();
            //var low = new MaxHeap<int>();
            //int median;
            //long sumOfMedians = 0;

            //foreach (string line in lines)
            //{
            //    int i = Convert.ToInt32(line);
            //    median = HeapSort.MaintainMedian(ref high, ref low, i);
            //    sumOfMedians += median;
            //}

            //Console.WriteLine("The sum of the medians is {0}", sumOfMedians);
        }
    }
}
