// https://leetcode.com/problems/find-peak-element/
public class FindPeakElementSolution
{
    public int FindPeakElement(int[] nums)
    {
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            var mid = (left + right) >> 1;

            if (nums[mid] > nums[mid + 1]) right = mid;
            else left = mid + 1;
        }

        return (left + right) >> 1;
    }
}