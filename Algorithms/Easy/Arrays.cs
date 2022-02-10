public class ArraysSolution
{
    // https://leetcode.com/problems/contains-duplicate/
    // Time: O(n) space: O(n)
    public bool ContainsDuplicate(int[] nums)
    {
        var seen = new HashSet<int>();

        foreach (var n in nums)
        {
            if (seen.Contains(n)) return true;
            seen.Add(n);
        }

        return false;
    }

    // Time: O(n * lg(n)) Space: O(1)
    public bool ContainsDuplicateWithSort(int[] nums)
    {
        Array.Sort(nums);

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] == nums[i]) return true;
        }

        return false;
    }

    // Time: O(n^2) Space: O(1)
    public bool ContainsDuplicateBruteForce(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
            for (int j = i + 1; j < nums.Length; j++)
                if (nums[i] == nums[j]) return true;

        return false;
    }

    // https://leetcode.com/problems/contains-duplicate-ii/
    // Time: O(n) Space: O(k) hashset to store at most k elements
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var seen = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > k) seen.Remove(nums[i - k - 1]);
            if (!seen.Add(nums[i])) return true;
        }

        return false;
    }
}