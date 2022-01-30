// Leetcode: https://leetcode.com/problems/maximum-subarray/

// Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
// A subarray is a contiguous part of an array.

public class MaxSubArraySolution
{
    public int MaxSubArray(int[] nums)
    {
        int max = int.MinValue;
        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            max = Math.Max(max, sum);

            if (sum < 0) sum = 0;
        }

        return max;
    }
}