# https://leetcode.com/problems/minimum-absolute-difference-in-bst/
import math
from typing import Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
class Solution:
    def getMinimumDifference(self, root: Optional[TreeNode]) -> int:
        self.prev = None
        self.min = math.inf

        def inorder_traverse(root: Optional[TreeNode]):
            if not root: return

            inorder_traverse(root.left)

            self.min = min(self.min, root.val - self.prev if self.prev != None else math.inf)
            self.prev = root.val

            inorder_traverse(root.right)

        inorder_traverse(root)
        return self.min
