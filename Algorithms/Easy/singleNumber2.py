# https://leetcode.com/problems/single-number-ii/
from typing import List

class Solution:
    def singleNumber(self, nums: List[int]) -> int:
        x1 = x2 = mask = 0

        for n in nums:
            x2 = x2 ^ (x1 & n)
            x1 = x1 ^ n
            mask = ~(x1 & x2)
            x2 = x2 & mask
            x1 = x1 & mask

        return x1