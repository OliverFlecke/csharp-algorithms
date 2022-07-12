# https://leetcode.com/problems/n-ary-tree-postorder-traversal/
from typing import List, Optional

# Definition for a Node.
class Node:
    def __init__(self, val=None, children=None):
        self.val = val
        self.children = children

class Solution:
    def preorder(self, root: Node) -> List[int]:
        result = []

        def dfs(node: Optional[Node]):
            if not node: return

            for n in node.children:
                dfs(n)

            result.append(node.val)

        dfs(root)
        return result