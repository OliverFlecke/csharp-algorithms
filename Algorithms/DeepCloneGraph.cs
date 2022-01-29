// Leetcode: https://leetcode.com/problems/clone-graph/

namespace Algorithms;

public class CloneGraphSolution
{
    public Node? CloneGraph(Node node)
    {
        if (node is null) return null;

        var originals = new Dictionary<int, Node>();
        var clones = new Dictionary<int, Node>();
        originals.Add(node.val, node);
        clones.Add(node.val, new Node(node.val));

        var queue = new LinkedList<Node>();
        queue.AddLast(node);

        while (queue.Count > 0)
        {
            var current = queue.First();
            queue.RemoveFirst();

            foreach (var neighbor in current.neighbors)
            {
                if (!originals.ContainsKey(neighbor.val))
                {
                    originals.Add(neighbor.val, neighbor);
                    clones.Add(neighbor.val, new Node(neighbor.val));

                    queue.AddLast(neighbor);
                }
            }
        }

        foreach (var key in clones.Keys)
        {
            foreach (var n in originals[key].neighbors)
            {
                clones[key].neighbors.Add(clones[n.val]);
            }
        }

        return clones[node.val];
    }

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}