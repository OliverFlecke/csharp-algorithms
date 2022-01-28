// From Leetcode: https://leetcode.com/problems/minimum-height-trees/
// Examples:
// Input: n = 4, edges = [[1,0],[1,2],[1,3]]
// Output: [1]
// Explanation: As shown, the height of the tree is 1 when the root is the node with label 1 which is the only MHT.

// Input: n = 6, edges = [[3,0],[3,1],[3,2],[3,4],[5,4]]
// Output: [3,4]

namespace Algorithms;

public class FindMinHeightTreesSolution {
    /// <summary>
    /// Find the node(s) which acting as roots will form the trees
    /// with minimum height.
    /// </summary>
    /// <param name="n">Number of nodes.</param>
    /// <param name="edges">Edges as an array of pairs.</param>
    /// <returns>List of nodes that as root would form the least heigh trees.</returns>
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if (n <= 2) return Enumerable.Range(0, n).ToList();

        var neighbors = new Dictionary<int, ISet<int>>();
        for (int i = 0; i < n; i++) // Initialize all nodes
        {
            neighbors.Add(i, new HashSet<int>());
        }

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var leaves = new LinkedList<int>();
        for (int i = 0; i < n; i++)
        {
            if (neighbors[i].Count == 1)
            {
                leaves.AddLast(i);
            }
        }

        var rest = n;
        while (rest > 2)
        {
            rest -= leaves.Count;

            var newLeaves = new LinkedList<int>();

            foreach (var leaf in leaves)
            {
                // Leaf only has one edge
                var parent = neighbors[leaf].First();
                neighbors[parent].Remove(leaf);
                if (neighbors[parent].Count == 1)
                {
                    newLeaves.AddLast(parent);
                }
            }

            leaves = newLeaves;
        }

        return leaves.ToList();
    }
}