# https://leetcode.com/problems/n-th-tribonacci-number/
class Solution:
    def tribonacci(self, n: int) -> int:
        cache = {}
        def run(n: int) -> int:
            if n == 0: return 0
            if n == 1 or n == 2: return 1
            if cache.get(n, -1) != -1: return cache[n]

            result = run(n - 1) + run(n - 2) + run(n - 3)
            cache[n] = result

            return result

        return run(n)