# https://leetcode.com/problems/search-in-rotated-sorted-array-ii/
from typing import List


class Solution:
    def search(self, nums: List[int], target: int) -> bool:
        left, right = 0, len(nums) - 1

        while left <= right:
            # Remove duplicates, simplifies to normal binary search
            while left < right and nums[left] == nums[left + 1]:
                left += 1
            while left < right and nums[right] == nums[right - 1]:
                right -= 1

            mid = (left + right) // 2

            if nums[mid] == target: return True

            if (nums[mid] < nums[0]) == (target < nums[0]):
                if nums[mid] < target: left = mid + 1
                else: right = mid - 1
            elif target < nums[0]: left = mid + 1
            else: right = mid - 1

        return False
