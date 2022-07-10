# https://leetcode.com/problems/triangle/
from typing import List

class Solution:
    def minimumTotal(self, triangle: List[List[int]]) -> int:
        height = len(triangle)
        memo = [[-1] * height for _ in range(height)]

        def dfs(i: int, j: int):
            if i == height: return 0
            if memo[i][j] != -1: return memo[i][j]

            left = triangle[i][j] + dfs(i + 1, j)
            right = triangle[i][j] + dfs(i + 1, j + 1)
            memo[i][j] = min(left, right)

            return memo[i][j]

        return dfs(0, 0)

    def minimumTotalIterative(self, triangle: List[List[int]]) -> int:
        n = len(triangle)
        next_row = triangle[-1][:]
        curr_row = [0] * n
        for i in range(n - 2, -1, -1):
            for j in range(i + 1):
                left = triangle[i][j] + next_row[j]
                right = triangle[i][j] + next_row[j + 1]
                curr_row[j] = min(left, right)

            curr_row, next_row = next_row, curr_row

        return next_row[0]