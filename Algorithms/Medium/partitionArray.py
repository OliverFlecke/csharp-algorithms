# https://leetcode.com/problems/partition-array-such-that-maximum-difference-is-k/
from typing import List

class Solution:
    def partitionArray(self, nums: List[int], k: int) -> int:
        if not list: return 0
        nums.sort()
        count = 1
        start = nums[0]

        for n in nums[1:]:
            if n - start > k:
                start = n
                count += 1

        return count