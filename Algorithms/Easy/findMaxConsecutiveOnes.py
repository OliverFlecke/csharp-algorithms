class Solution:
    def findMaxConsecutiveOnes(self, nums: List[int]) -> int:
        result = 0
        current = 0
        for i in range(len(nums)):
            current = current + 1 if nums[i] == 1 else 0
            result = max(current, result)

        return result