# https://leetcode.com/problems/binary-tree-tilt/
from linecache import cache
from typing import Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def findTilt(self, root: Optional[TreeNode]) -> int:
        if not root: return 0

        return abs(self.findSum(root.left) - self.findSum(root.right)) + self.findTilt(root.left) + self.findTilt(root.right)

    @cache
    def findSum(self, root: Optional[TreeNode]) -> int:
        if not root: return 0

        return root.val + self.findSum(root.left) + self.findSum(root.right)

    def findTiltAlt(self, root: Optional[TreeNode]) -> int:
        tilt = 0

        def dfs(root: Optional[TreeNode]) -> int:
            if not root: return 0

            nonlocal tilt
            l = dfs(root.left)
            r = dfs(root.right)
            tilt += abs(l - r)

            return l + r + root.val

        dfs(root)
        return tilt
