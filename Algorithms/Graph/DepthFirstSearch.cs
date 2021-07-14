using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graph
{
    public partial class Graphs
    {
        public static void FindStronglyConnectedComponents(ref Dictionary<int, List<int>> graph, string outputFile)
        {
            // Kosaraju's Two-Pass Algorithm
            var nodes = GetNodesWithProperties(graph);
            var reversed = ReverseGraph(graph);
            var stack = new Stack<int>();

            graph = null; // free up memory
            var SCCs = new List<List<int>>();

            foreach (var node in nodes)
            {
                if (node.Value.Explored == false)
                {
                    KosarajusFirstPass(ref nodes, ref reversed, ref stack, node.Key );                    
                }
            }

            ResetExploredNodes(ref nodes);

            while(stack.Count > 0)
            {
                var node = stack.Pop();

                if (!nodes[node].Explored)
                {
                    SCCs.Add(new List<int>());
                    KosarajusSecondPass(ref nodes, ref SCCs, node);
                }
            }

            SaveListSizesToFile(SCCs, outputFile);
        }

        public static void KosarajusFirstPass(ref Dictionary<int, Node> nodes,
                                              ref Dictionary<int, List<int>> reversed,
                                              ref Stack<int> stack,
                                              int node)
        {
            nodes[node].Explored = true;

            if (reversed.ContainsKey(node))
            {
                foreach (var neighbor in reversed[node])
                {
                    if (!nodes[neighbor].Explored)
                    {
                        KosarajusFirstPass(ref nodes, ref reversed, ref stack, neighbor);
                    }
                }
            }          
            
            stack.Push(node);
        }

        public static void KosarajusSecondPass(ref Dictionary<int, Node> nodes,
                                               ref List<List<int>> sccs,
                                               int node)
        {
            sccs[sccs.Count() - 1].Add(node);
            nodes[node].Explored = true;

            
            foreach(var neighbor in nodes[node].Edges)
            {
                if (nodes.ContainsKey(neighbor))
                {
                    if (!nodes[neighbor].Explored)
                    {
                        KosarajusSecondPass(ref nodes, ref sccs, neighbor);
                    }
                }
                
            }
        }

        private static void ResetExploredNodes(ref Dictionary<int, Node> nodes)
        {
            foreach(var node in nodes)
            {
                node.Value.Explored = false;
            }
        }

        public static void SaveListSizesToFile(List<List<int>> lists, string outputFile)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(outputFile))
            {
                foreach (var list in lists)
                {
                    file.WriteLine(list.Count.ToString());
                    
                }
            }
            
        }

        public static Stack<int> DepthFirstSearchTopologicalSort(Dictionary<int, List<int>> graph, bool verbose = true)
        {
            var result = new Stack<int>();
            var nodes = Graphs.GetNodesWithProperties(graph);

            foreach(var node in nodes)
            {
                if(node.Value.Explored == false)
                {
                    DepthFirstSearchTraversalNode(ref nodes, node.Value.Id, ref result);
                }
            }

            if (verbose)
            {
                bool firstElementInStack = true;
                foreach(var node in result)
                {
                    if (firstElementInStack)
                    {
                        Console.Write("The topological ordering is: {0}", node);
                        firstElementInStack = false;
                    }
                    else
                    {
                        Console.Write(", {0}", node);
                    }
                }
            }

            return result;
        }

        public static void DepthFirstSearchTraversalNode(ref Dictionary<int, Node> nodes, int start, ref Stack<int> stack)
        {

            nodes[start].Explored = true;

            foreach (var edge in nodes[start].Edges)
            {
                if (!nodes[edge].Explored)
                {
                    DepthFirstSearchTraversalNode(ref nodes, edge, ref stack);
                }
            }

            stack.Push(start);
        }

        public static List<int> DepthFirstSearchTraversalList(ref Dictionary<int, Node> nodes, int start)
        {
            // returns the path of nodes required to search all nodes
            var result = new List<int>();

            var stack = new Stack<int>(); // LIFO-queue

            stack.Push(start);
            nodes[start].Explored = true;
            result.Add(start);

            foreach (var edge in nodes[start].Edges)
            {
                if (!nodes[edge].Explored)
                {
                    var explored = DepthFirstSearchTraversalList(ref nodes, edge);
                    result.AddRange(explored);
                }
            }            

            return result;
        }

    }
}
