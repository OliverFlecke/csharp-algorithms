// https://leetcode.com/problems/search-in-rotated-sorted-array/

public class SearchInRotatedSortedArraySolution
{
    // Idea is to check that the target and mid are at the same part of the array
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] == target) return mid;

            // Check that target and nums[mid] is in the same part of the array.
            if ((nums[mid] < nums[0]) == (target < nums[0]))
            {
                if (nums[mid] < target) left = mid + 1;
                else right = mid - 1;
            }
            else if (target < nums[0]) left = mid + 1;
            else right = mid - 1;
        }

        return -1;
    }
}