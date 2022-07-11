# https://leetcode.com/problems/recover-binary-search-tree/
from typing import Optional
import math

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def recoverTree(self, root: Optional[TreeNode], l = None, r = None) -> None:
        """
        Do not return anything, modify root in-place instead.
        """
        self.first = self.second = None
        self.prev = TreeNode(-math.inf)

        def traverse(root: Optional[TreeNode]):
            if not root: return

            traverse(root.left)

            if not self.first and self.prev.val >= root.val: self.first = self.prev
            if self.first and self.prev.val >= root.val: self.second = root
            self.prev = root

            traverse(root.right)

        traverse(root)
        self.first.val, self.second.val = self.second.val, self.first.val
