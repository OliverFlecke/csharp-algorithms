# https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/
from typing import Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def sumRootToLeaf(self, root: Optional[TreeNode]) -> int:
        self.sum = 0
        def dfs(root: Optional[TreeNode], path: int = 0):
            if not root: return
            if not root.left and not root.right:
                self.sum += (path << 1) + root.val
                return

            dfs(root.left, (path << 1) + root.val)
            dfs(root.right, (path << 1) + root.val)

        dfs(root)
        return self.sum