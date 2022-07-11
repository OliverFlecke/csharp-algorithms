# https://leetcode.com/problems/house-robber/
from typing import List

class Solution:
    def __init__(self):
        self.cache = {}

    def rob(self, nums: List[int]) -> int:
        if not nums: return 0
        if len(nums) == 1: return nums[0]
        if len(nums) == 2: return max(nums)
        if self.cache.get(len(nums), -1) != -1: return self.cache[len(nums)]

        self.cache[len(nums)] = max(nums[0] + self.rob(nums[2:]), nums[1] + self.rob(nums[3:]))
        return self.cache[len(nums)]
