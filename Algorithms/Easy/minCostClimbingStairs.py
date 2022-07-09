# https://leetcode.com/problems/min-cost-climbing-stairs/

from typing import List

class Solution:
    def minCostClimbingStairs(self, cost: List[int]) -> int:
        cache = {}

        def climb(step: int) -> int:
            if step >= len(cost): return 0
            if cache.get(step, -1) != -1: return cache[step]

            result = cost[step] + min(climb(step + 1), climb(step + 2))
            cache[step] = result
            return result


        return min(climb(0), climb(1))