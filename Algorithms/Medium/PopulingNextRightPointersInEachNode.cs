
// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
public class PopulatingNextRightPointersInEachNodeSolution // Binary tree
{
    public class Node
    {
        public int val;
        public Node? left;
        public Node? right;
        public Node? next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    public Node? Connect(Node? root)
    {
        if (root is null) return null;

        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var length = queue.Count;
            Node? previous = null;
            while (length > 0)
            {
                var current = queue.Dequeue();
                if (current.left is not null) queue.Enqueue(current.left);
                if (current.right is not null) queue.Enqueue(current.right);

                if (previous is not null) previous.next = current;
                previous = current;
                length--;
            }
        }

        return root;
    }
}