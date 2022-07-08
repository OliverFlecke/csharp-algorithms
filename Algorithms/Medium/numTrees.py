# https://leetcode.com/problems/unique-binary-search-trees/
class Solution:
    cache = {}

    def numTrees(self, n: int) -> int:
        if n == 0 or n == 1: return 1

        if self.cache.get(n, -1) != -1: return self.cache[n]

        result = 0
        for i in range(n):
            result += self.numTrees(i) * self.numTrees(n - i - 1)

        self.cache[n] = result
        return result