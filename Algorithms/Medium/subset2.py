# https://leetcode.com/problems/subsets-ii/
from typing import List

class Solution:
    def subsetsWithDup(self, nums: List[int]) -> List[List[int]]:
        nums.sort()
        result = []

        def backtrack(size, start, subset):
            if size == len(subset):
                if subset not in result: result.append(subset)
                return

            for i in range(start, len(nums)):
                backtrack(size, i + 1, subset + [nums[i]])


        for i in range(len(nums) + 1):
            backtrack(i, 0, [])

        return result