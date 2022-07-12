# https://leetcode.com/problems/range-addition-ii/
from typing import List

class Solution:
    def maxCount(self, m: int, n: int, ops: List[List[int]]) -> int:
        if not ops: return m * n

        return min(a for a, _ in ops) * min(b for _, b in ops)

