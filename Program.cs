using System;

// Author: Yanzhi Wang
// Purpose: Implements a depth-first search algorithm for traversing a graph represented by an adjacency list.
// Restrictions: Assumes that the graph is represented by an adjacency list where each index in the outer array represents a vertex, and the inner arrays represent the vertices that are adjacent to that vertex.
// Also assumes that the graph is represented using the EColor enumeration.

namespace DFS
{
    // Define enumeration for vertex colors
    public enum EColor { Red, Green, Blue, Yellow }

    class Program
    {
        // Define adjacency list for graph
        static int[][] colorAGraph = new int[][]
        {
            new int[] {1, 2},       // Red:   1, 2
            new int[] {0, 2, 3},    // Green: 0, 2, 3
            new int[] {0, 1, 3},    // Blue:  0, 1, 3
            new int[] {1, 2, 4},    // Yellow:1, 2, 4
            new int[] {3}           // Purple:3
        };

        static void Main(string[] args)
        {
            // Call DFS with starting vertex of Red
            DFS(EColor.Red);
        }

        // Depth-first search algorithm
        static void DFS(EColor eState)
        {
            // Initialize visited array
            bool[] visited = new bool[colorAGraph.Length];

            // Call helper method with starting vertex and visited array
            DFSUtil(eState, visited);
        }

        // DFS helper method
        static void DFSUtil(EColor v, bool[] visited)
        {
            // Mark current vertex as visited
            visited[(int)v] = true;

            // Print current vertex to console
            Console.Write(v.ToString() + " ");

            // Get adjacency list for current vertex
            int[] thisStateList = colorAGraph[(int)v];

            // Traverse adjacent vertices recursively
            if (thisStateList != null)
            {
                foreach (int n in thisStateList)
                {
                    if (!visited[n])
                    {
                        DFSUtil((EColor)n, visited);
                    }
                }
            }
        }
    }
}
