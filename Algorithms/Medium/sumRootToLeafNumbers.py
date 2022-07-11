# https://leetcode.com/problems/sum-root-to-leaf-numbers/
from typing import Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

def isLeaf(node: TreeNode) -> bool:
    return not node.left and not node.right

class Solution:
    def sumNumbers(self, root: Optional[TreeNode]) -> int:
        if not root: return 0

        def helper(node: Optional[TreeNode], value: int) -> int:
            if not node: return 0
            newValue = 10 * value + node.val

            if isLeaf(node):
                return newValue

            return helper(node.left, newValue) + helper(node.right, newValue)

        return helper(root, 0)

    def sumNumbersWithStack(self, root: Optional[TreeNode]) -> int:


        if not root: return 0

        stack, result = [root], 0

        def add(node: Optional[TreeNode], val: int):
            if node:
                node.val += val * 10
                stack.append(node)

        while stack:
            node = stack.pop()
            if isLeaf(node): result += node.val

            add(node.left, node.val)
            add(node.right, node.val)

        return result

