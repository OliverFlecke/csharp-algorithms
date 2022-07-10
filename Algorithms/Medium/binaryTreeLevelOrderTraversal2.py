from typing import List, Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def levelOrderBottom(self, root: Optional[TreeNode]) -> List[List[int]]:
        if not root: return []

        result = []
        queue = [root]

        while queue:
            l = len(queue)
            level = []

            while l != 0:
                current = queue.pop(0)
                level.append(current.val)

                if current.left: queue.append(current.left)
                if current.right: queue.append(current.right)

                l -= 1

            result.insert(0, level)

        return result

