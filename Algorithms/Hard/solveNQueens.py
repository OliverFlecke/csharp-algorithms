# https://leetcode.com/problems/n-queens/
from typing import List

class Solution:
    def solveNQueens(self, n: int) -> List[List[str]]:
        result = []

        # Queens list contains the col positions of each queen
        def dfs(queens: List[int] = [], xy_diff: List[int] = [], xy_sum: List[int] = []):
            p = len(queens)
            if p == n:
                result.append(queens)
                return

            for q in range(n):
                #  Check queen not already in col or diagonal
                if q not in queens and p - q not in xy_diff and p + q not in xy_sum:
                    dfs(queens + [q], xy_diff + [p - q], xy_sum + [p + q])

        def rowToString(i: int) -> str:
            return "." * i + "Q" + "." * (n - i - 1)

        dfs()
        return [[rowToString(i) for i in row] for row in result]
