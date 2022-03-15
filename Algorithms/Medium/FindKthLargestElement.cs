// https://leetcode.com/problems/kth-largest-element-in-an-array/
public class FindKthLargestSolution
{
    public int FindKthLargest(int[] nums, int k)
    {
        var sorted = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            Insert(nums[i]);
        }

        return sorted[k - 1];

        void Insert(int n)
        {
            int i = 0;
            for (; i < k && i < sorted.Count; i++)
            {
                if (sorted[i] <= n)
                {
                    sorted.Insert(i, n);
                    return;
                }
            }

            if (i < k) sorted.Add(n);
        }
    }

    // Just sort the numbers in O(n * lg(n)) time and constant space
    public int FindKthLargestSimple(int[] nums, int k)
    {
        Array.Sort(nums);

        return nums[nums.Length - k];
    }
}