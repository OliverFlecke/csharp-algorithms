# https://leetcode.com/problems/binary-tree-right-side-view/
from typing import Optional, List

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def rightSideView(self, root: Optional[TreeNode]) -> List[int]:
        if not root: return []
        result = []
        queue = [root]

        while queue:
            l = len(queue)

            first = True
            while l != 0:
                current = queue.pop(0)
                if first:
                    result.append(current.val)
                    first = False

                if current.right: queue.append(current.right)
                if current.left: queue.append(current.left)

                l -= 1

        return result