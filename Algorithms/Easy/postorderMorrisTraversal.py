# https://leetcode.com/problems/binary-tree-postorder-traversal/
from typing import Optional, List

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def postorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        def morris(root: Optional[TreeNode]) -> List[int]:
            while root:
                if not root.right:
                    yield root.val
                    root = root.left
                else:
                    prev = root.right
                    while prev.left and prev.left != root:
                        prev = prev.left

                    if not prev.left:
                        yield root.val
                        prev.left = root
                        root = root.right
                    else:
                        prev.left = None
                        root = root.left


        return list(morris(root))[::-1]