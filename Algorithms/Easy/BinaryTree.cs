public class BinaryTreeSolutions
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    // https://leetcode.com/problems/invert-binary-tree/
    public TreeNode? InvertTree(TreeNode? root)
    {
        if (root is null) return null;

        var temp = root.left;
        root.left = InvertTree(root.right);
        root.right = InvertTree(temp);

        return root;
    }

    // https://leetcode.com/problems/binary-tree-paths/
    public IList<string> BinaryTreePaths(TreeNode? root)
    {
        if (root is null) return Array.Empty<string>();
        if (root.left is null && root.right is null)
            return new List<string> { root.val.ToString() };

        var result = new List<string>();
        foreach (var path in BinaryTreePaths(root.left))
        {
            result.Add($"{root.val}->{path}");
        }
        foreach (var path in BinaryTreePaths(root.right))
        {
            result.Add($"{root.val}->{path}");
        }

        return result;
    }

    // https://leetcode.com/problems/sum-of-left-leaves/
    public int SumOfLeftLeaves(TreeNode? root, bool isLeftLeaf = false)
    {
        if (root is null) return 0;
        if (root.right is null && root.left is null) return isLeftLeaf ? root.val : 0;

        return SumOfLeftLeaves(root.left, true) + SumOfLeftLeaves(root.right, false);
    }

    // https://leetcode.com/problems/binary-tree-level-order-traversal/
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root is null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var length = queue.Count;

        while (queue.Count > 0)
        {
            var level = new List<int>();
            while (length-- > 0)
            {
                var node = queue.Dequeue();
                level.Add(node.val);

                if (node.left is not null) queue.Enqueue(node.left);
                if (node.right is not null) queue.Enqueue(node.right);
            }

            result.Add(level);
            length = queue.Count;
        }

        return result;
    }
}

public class BinarySearchTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    // https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        while (true)
        {
            if (p.val < root.val && q.val < root.val) root = root.left;
            else if (p.val > root.val && q.val > root.val) root = root.right;
            else return root;
        }
    }
}