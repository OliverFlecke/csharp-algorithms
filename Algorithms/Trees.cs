public class MaxDepthSolution
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public int MaxDepthRecursive(TreeNode root)
    {
        if (root is null) return 0;

        return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
    }

    public int MaxDepth(TreeNode root)
    {
        if (root is null) return 0;

        var depth = 0;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var length = queue.Count;

        while (queue.Count > 0)
        {
            while (length > 0)
            {
                var current = queue.Dequeue();
                length--;

                if (current.right is not null) queue.Enqueue(current.right);
                if (current.left is not null) queue.Enqueue(current.left);
            }

            depth++;
            length = queue.Count;
        }

        return depth;
    }

    // https://leetcode.com/problems/minimum-depth-of-binary-tree/
    public int MinDepth(TreeNode root)
    {
        if (root is null) return 0;

        if (root.left is null) return MinDepth(root.right) + 1;
        if (root.right is null) return MinDepth(root.left) + 1;

        return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
    }

    // https://leetcode.com/problems/path-sum/
    public bool HasPathSum(TreeNode? node, int target)
    {
        if (node is null) return false;
        if (node.right is null && node.left is null) return target == node.val;

        return HasPathSum(node.left, target - node.val)
            || HasPathSum(node.right, target - node.val);
    }
}

public class SortedArryToBSTSolution
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return Helper(0, nums.Length - 1);

        TreeNode Helper(int start, int end)
        {
            if (start > end) return null;
            var mid = (start + end) / 2;

            return new TreeNode(
                nums[mid],
                Helper(start, mid - 1),
                Helper(mid + 1, end));
        }
    }
}

//  https://leetcode.com/problems/balanced-binary-tree/
public class BalancedBinaryTreeSolution
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public bool IsBalanced(TreeNode root)
    {
        return Height(root) != int.MinValue;

        int Height(TreeNode node)
        {
            if (node is null) return 0;

            var left = Height(node.left);
            var right = Height(node.right);

            if (left == int.MinValue || right == int.MinValue) return int.MinValue;

            return Math.Abs(left - right) > 1
                ? int.MinValue
                : Math.Max(left, right) + 1;
        }
    }
}

public class TreeTraversalSolution
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

    // https://leetcode.com/problems/binary-tree-preorder-traversal/
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        Helper(root);

        return result;

        void Helper(TreeNode? node)
        {
            if (node is null) return;

            result.Add(node.val);
            Helper(node.left);
            Helper(node.right);
        }
    }

    public IList<int> PostorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        Helper(root);

        return result;

        void Helper(TreeNode? node)
        {
            if (node is null) return;

            Helper(node.left);
            Helper(node.right);
            result.Add(node.val);
        }
    }
}