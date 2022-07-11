# https://leetcode.com/problems/unique-binary-search-trees-ii/
from typing import List, Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
class Solution:
    def generateTrees(self, n: int) -> List[Optional[TreeNode]]:
        if n == 0: return []

        def helper(start, end):
            if start > end: return [None]

            trees = []
            for v in range(start, end + 1):
                left = helper(start, v - 1)
                right = helper(v + 1, end)

                for l in left:
                    for r in right:
                        root = TreeNode(v)
                        root.left = l
                        root.right = r

                        trees.append(root)

            return trees

        return helper(1, n)
