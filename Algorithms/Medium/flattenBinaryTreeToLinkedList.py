# https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
from typing import Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def __init__(self):
        self.prev = None

    def flatten(self, root: Optional[TreeNode]) -> None:
        """
        Do not return anything, modify root in-place instead.
        """
        if not root: return

        self.flatten(root.right)
        self.flatten(root.left)

        root.right, root.left, self.prev = self.prev, None, root
