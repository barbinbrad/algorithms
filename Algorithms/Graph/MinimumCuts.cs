using System.Collections.Generic;
using Utilities;

namespace Algorithms.Graph
{
    public partial class Graphs
    {
        public static int MinimumCuts(Dictionary<int, List<int>> adjacentList, List<int> nodes)
        {
            // Krager's Algorithm

            int superNodeId = adjacentList.Count + 1;

            while ( nodes.Count > 2)
            {
                // Get list of edges
                int m = GetNumberOfEdges(adjacentList, nodes);
                int[,] edges = GetEdges(m, adjacentList, nodes);


                // Select a random edge
                int randomEdge = Helpers.GetRandomNumber(0, edges.Length/2);

                // Combine the nodes between the random edge into a new node
                int u = edges[randomEdge, 0];
                int v = edges[randomEdge, 1];

                List<int> connectedToVertexU = adjacentList[u];
                List<int> connectedToVertexV = adjacentList[v];

                foreach(var vertex in connectedToVertexV)
                {
                    connectedToVertexU.Add(vertex);
                }

                nodes.RemoveAt(nodes.IndexOf(v));
                adjacentList.Remove(v);

                

                for (int i = 0; i<nodes.Count; i++)
                {

                    for (int j = 0; j < adjacentList[nodes[i]].Count; j++)
                    {
                        if (adjacentList[nodes[i]][j] == u)
                            adjacentList[nodes[i]][j] = superNodeId; 
                        if (adjacentList[nodes[i]][j] == v)
                            adjacentList[nodes[i]][j] = superNodeId;
                        
                    }
                }

                List<int> values = adjacentList[u];
                adjacentList.Remove(u);
                adjacentList.Add(superNodeId, values);

                int newIndex = nodes.IndexOf(u);
                nodes[newIndex] = superNodeId;

                // Remove any self-loops from super node
                int indexOfSuperNode = 0;
                int lengthOfSuperNode = adjacentList[superNodeId].Count;

                while(indexOfSuperNode < lengthOfSuperNode)
                {
                    if(adjacentList[superNodeId][indexOfSuperNode] == superNodeId)
                    {
                        adjacentList[superNodeId].RemoveAt(indexOfSuperNode);
                        lengthOfSuperNode--;
                    }
                    else
                    {
                        indexOfSuperNode++;
                    }
                }

                superNodeId++;

            }


            var output = adjacentList.GetValueOrDefault(nodes[0]);

            return output.Count;
        }

        
    }
}
