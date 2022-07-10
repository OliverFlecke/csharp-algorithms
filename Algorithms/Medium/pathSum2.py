# https://leetcode.com/problems/path-sum-ii/
from typing import List, Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def pathSum(self, root: Optional[TreeNode], targetSum: int) -> List[List[int]]:
        result = []

        def isLeaf(node: TreeNode) -> bool:
            return not node.left and not node.right

        def helper(node: Optional[TreeNode], path: List[int] = []):
            if not node: return
            if isLeaf(node):
                path = path + [node.val]
                if sum(path) == targetSum:
                    result.append(path)
                return

            helper(node.left, path + [node.val])
            helper(node.right, path + [node.val])

        helper(root)

        return result