// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
public class SearchRangeSolution
{
    public int[] SearchRange(int[] nums, int target)
    {
        var result = new int[] { -1, -1 };
        if (nums.Length == 0) return result;

        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            int mid = (left + right) >> 1;

            if (nums[mid] < target) left = mid + 1;
            else right = mid;
        }

        if (nums[left] != target) return result;
        else result[0] = left;

        right = nums.Length - 1;
        while (left < right)
        {
            int mid = 1 + ((left + right) >> 1);

            if (nums[mid] > target) right = mid - 1;
            else left = mid;
        }

        result[1] = right;

        return result;
    }
}