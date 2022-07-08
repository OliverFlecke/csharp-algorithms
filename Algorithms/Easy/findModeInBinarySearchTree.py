# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    prev = None
    max_count = 0
    current_count = 0
    result = []

    def findMode(self, root: Optional[TreeNode]) -> List[int]:
        self.inorder_traverse(root)

        return self.result

    def inorder_traverse(self, root: Optional[TreeNode]):
        if not root: return

        self.inorder_traverse(root.left)

        self.current_count = 1 if root.val != self.prev else self.current_count + 1

        if self.current_count == self.max_count:
            self.result.append(root.val)
        elif self.current_count > self.max_count:
            self.result = [root.val]
            self.max_count = self.current_count

        self.prev = root.val
        self.inorder_traverse(root.right)
