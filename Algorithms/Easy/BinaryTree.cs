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

    // https://leetcode.com/problems/binary-tree-preorder-traversal/
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        if (root is null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var length = queue.Count;

        while (queue.Count > 0)
        {
            while (length > 0)
            {
                var current = queue.Dequeue();
                result.Add(current.val);

                if (current.left is not null) queue.Enqueue(current.left);
                if (current.right is not null) queue.Enqueue(current.right);

                length--;
            }

            length = queue.Count;
        }

        return result;
    }

    // https://leetcode.com/problems/kth-smallest-element-in-a-bst/
    public int KthSmallest(TreeNode? root, int k)
    {
        var stack = new Stack<TreeNode>();
        while (root is not null || stack.Count != 0)
        {
            while (root is not null)
            {
                stack.Push(root);
                root = root.left;
            }

            root = stack.Pop();
            if (--k == 0) return root.val;
            root = root.right;
        }

        return -1;
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

    // https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root is null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var length = queue.Count;
        var zig = false;

        while (queue.Count > 0)
        {
            var level = new LinkedList<int>();
            while (length-- > 0)
            {
                var node = queue.Dequeue();

                if (zig) level.AddFirst(node.val);
                else level.AddLast(node.val);

                if (node.left is not null) queue.Enqueue(node.left);
                if (node.right is not null) queue.Enqueue(node.right);
            }

            zig = !zig;
            result.Add(level.ToList());
            length = queue.Count;
        }

        return result;
    }

    // https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        var preorderIndex = 0;
        var map = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++)
            map[inorder[i]] = i;

        return ArrayToTree(0, preorder.Length - 1);

        TreeNode ArrayToTree(int left, int right)
        {
            if (left > right) return null;

            var rootValue = preorder[preorderIndex++];
            var root = new TreeNode(rootValue);

            root.left = ArrayToTree(left, map[rootValue] - 1);
            root.right = ArrayToTree(map[rootValue] + 1, right);

            return root;
        }
    }

    // https://leetcode.com/problems/binary-tree-maximum-path-sum/
    public int MaxPathSum(TreeNode? root)
    {
        int max = int.MinValue;
        Traverse(root);
        return max;

        int Traverse(TreeNode? node)
        {
            if (node is null) return 0;

            int left = Math.Max(0, Traverse(node.left));
            int right = Math.Max(0, Traverse(node.right));

            max = Math.Max(max, left + right + node.val);
            return Math.Max(left, right) + node.val;
        }
    }

    // https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
    public TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode p, TreeNode q)
    {
        if (root is null || root == p || root == q) return root;

        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);

        if (left is not null && right is not null) return root;

        return left ?? right;
    }


    // https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
    public class BinaryTreeCodec
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode? root)
        {
            var list = new List<string>();
            Recurse(root);

            return string.Join(",", list);

            void Recurse(TreeNode? node)
            {
                if (node is null)
                {
                    list.Add("#");
                    return;
                }

                list.Add(node.val.ToString());
                Recurse(node.left);
                Recurse(node.right);
            }
        }

        // Decodes your encoded data to tree.
        public TreeNode? deserialize(string data)
        {
            var queue = new Queue<string>(data.Split(","));
            return Recurse();

            TreeNode? Recurse()
            {
                if (int.TryParse(queue.Dequeue(), out int value))
                {
                    var root = new TreeNode(value)
                    {
                        left = Recurse(),
                        right = Recurse()
                    };
                    return root;
                }
                else return null;
            }
        }
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