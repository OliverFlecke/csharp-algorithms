# https://leetcode.com/problems/diameter-of-binary-tree/
# Definition for a binary tree node.
from typing import Optional

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def diameterOfBinaryTree(self, root: Optional[TreeNode]) -> int:
        self.best = 0

        def dfs(root: Optional[TreeNode]) -> int:
            if not root: return 0

            l, r = dfs(root.left), dfs(root.right)
            self.best = max(self.best, l + r)

            return 1 + max(l, r)

        dfs(root)
        return self.best