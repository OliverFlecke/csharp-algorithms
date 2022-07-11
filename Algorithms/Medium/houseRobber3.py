# https://leetcode.com/problems/house-robber-iii/
from typing import Optional, Tuple

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def __init__(self):
        self.cache = {}

    def rob(self, root: Optional[TreeNode]) -> int:
        if not root: return 0
        if self.cache.get(root, -1) != -1: return self.cache[root]

        rob = 0
        if root.left:
            rob += self.rob(root.left.left) + self.rob(root.left.right)
        if root.right:
            rob += self.rob(root.right.left) + self.rob(root.right.right)

        self.cache[root] = max(rob + root.val, self.rob(root.left) + self.rob(root.right))
        return self.cache[root]

    def robSimple(self, root: Optional[TreeNode]) -> int:
        # Idea: return a tuple where 1st element is sum if child is not robbed and
        # 2nd element is sum if child IS robbed
        def helper(root: Optional[TreeNode]) -> Tuple[int, int]:
            if not root: return (0, 0)

            l = helper(root.left)
            r = helper(root.right)

            # If not robbing root, return max of left and right, no matter if they where robbed or not
            # else if robbing root, only look sum from not robbing direct children
            return (max(l) + max(r), root.val + l[0] + r[0])

        return max(helper(root))
