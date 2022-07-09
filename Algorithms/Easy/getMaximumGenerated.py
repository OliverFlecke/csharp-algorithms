# https://leetcode.com/problems/get-maximum-in-generated-array/
class Solution:
    def getMaximumGenerated(self, n: int) -> int:
        if n == 0: return 0
        nums = [0] * (n + 1)
        nums[0] = 0
        nums[1] = 1

        for i in range(1, n // 2 + 1):
            nums[2 * i] = nums[i]
            if 2 * i + 1 < n + 1: nums[2 * i + 1] = nums[i] + nums[i + 1]

        return max(nums)