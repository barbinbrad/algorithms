using System;
using System.Collections.Generic;

namespace Algorithms.Graph
{
    public partial class Graphs
    {
        public static int BreadthFirstSearchShortestPath(Dictionary<int, List<int>> graph, int start, int target, bool verbose = true)
        {
            // returns the number of jumps between two nodes

            var queue = new Queue<int>(); // FIFO-queue
            var nodes = GetNodesWithProperties(graph);
            var targetWasFound = false;

            queue.Enqueue(start);
            nodes[start].Explored = true;
            nodes[start].Distance = 0;

            while( queue.Count > 0)
            {
                var current = queue.Dequeue();
                if( current == target )
                {
                    targetWasFound = true;
                    break;
                }

                var edges = nodes[current].Edges;
                foreach(var neighbor in edges)
                {
                    if (!nodes[neighbor].Explored)
                    {
                        nodes[neighbor].Explored = true;
                        nodes[neighbor].Parent = current;
                        nodes[neighbor].Distance = nodes[current].Distance + 1;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            if(targetWasFound)
            {
                if (verbose)
                {
                    var path = new Stack<int>(); // LIFO-queue
                    var next = nodes[target].Parent;
                    int jumps = 0;

                    path.Push(target);

                    while (next != 0) // Assume that only nodes with no parent can have node.Parent = 0
                    {
                        path.Push(next);
                        next = nodes[next].Parent;
                        jumps++;
                    }

                    bool firstElementInList = true;

                    foreach (var node in path)
                    {
                        if (firstElementInList)
                        {
                            Console.Write("The shortest path from {0} to {1} is: {2}", start, target, node);
                            firstElementInList = false;
                        }
                        else
                        {
                            Console.Write(", {0}", node);
                        }
                    }
                }
                

                return nodes[target].Distance;
            }
            else
            {
                Console.Write("The target {0} could not be found from the root node {1}", target, start);
                return -1;
            }
        }

        public static List<List<int>> BreadthFirstSearchConnectivity(Dictionary<int, List<int>> graph)
        {
            var network = new List<List<int>>();
            var nodes = GetNodesWithProperties(graph);

            foreach(var node in nodes)
            {
                if (node.Value.Explored == false)
                {
                    var connected = BreadthFirstSearchTraversal(ref nodes, node.Value.Id);
                    network.Add(connected);
                }
            }

            return network;
        }

        public static List<int> BreadthFirstSearchTraversal(ref Dictionary<int, Node> nodes, int start)
        {
            // returns the path of nodes required to search all nodes
            var result = new List<int>();

            var queue = new Queue<int>(); // FIFO-queue

            queue.Enqueue(start);
            nodes[start].Explored = true;
            result.Add(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var edges = nodes[current].Edges;

                foreach (var neighbor in edges)
                {
                    if (!nodes[neighbor].Explored)
                    {
                        nodes[neighbor].Explored = true;
                        nodes[neighbor].Parent = current;
                        queue.Enqueue(neighbor);

                        result.Add(neighbor);
                    }
                }
            }

            return result;
        }
    }
}
