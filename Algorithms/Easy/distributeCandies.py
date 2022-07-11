# https://leetcode.com/problems/distribute-candies/
from typing import List

class Solution:
    def distributeCandies(self, candyType: List[int]) -> int:
        max_types = len(candyType) // 2
        eaten = set()
        result = 0

        for c in candyType:
            if c not in eaten:
                eaten.add(c)
                result += 1
                if result >= max_types: break

        return result