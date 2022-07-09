# https://leetcode.com/problems/n-queens-ii/
from typing import List

class Solution:
    def totalNQueens(self, n: int) -> int:
        result = []

        def dfs(queens: List[str], xy_diff: List, xy_sum: List):
            p = len(queens)
            if p == n:
                result.append(queens)
                return

            for q in range(n):
                if q not in queens and p - q not in xy_diff and p + q not in xy_sum:
                    dfs(queens + [q], xy_diff + [p - q], xy_sum + [p + q])

        dfs([], [], [])
        return len(result)