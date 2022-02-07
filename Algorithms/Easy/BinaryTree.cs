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
}