# https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
from typing import List, Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def buildTree(self, inorder: List[int], postorder: List[int]) -> Optional[TreeNode]:
        m = {}
        for i, val in enumerate(inorder): m[val] = i

        def search(low: int, high: int):
            if low > high: return None

            x = TreeNode(postorder.pop())
            mid = m[x.val]
            x.right = search(mid + 1, high)
            x.left = search(low, mid - 1)

            return x

        return search(0, len(inorder) - 1)