# https://leetcode.com/problems/binary-tree-preorder-traversal/
from typing import Optional, List

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
class Solution:
    def preorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        def morris(root: Optional[TreeNode]) -> List[int]:
            while root:
                if not root.left:
                    yield root.val
                    root = root.right
                else:
                    prev = root.left
                    while prev.right and prev.right != root:
                        prev = prev.right

                    if not prev.right:
                        yield root.val
                        prev.right = root
                        root = root.left
                    else:
                        prev.right = None
                        root = root.right


        return list(morris(root))