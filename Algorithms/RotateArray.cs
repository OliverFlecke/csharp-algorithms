// Leetcode: https://leetcode.com/problems/rotate-array/

// Time: O(n)
// Space: O(1)

public class RotateArraySolution
{
    public void Rotate(int[] nums, int k)
    {
        if (nums is null || nums.Length <= 1) return;

        k %= nums.Length;

        Reverse(nums, 0, nums.Length - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, nums.Length - 1);
    }

    public void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            var temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;

            start++;
            end--;
        }
    }
}