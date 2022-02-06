public class MajorityElementSolution
{
    // Time: O(n)
    // Space: O(n)
    // https://leetcode.com/problems/majority-element/
    public int MajorityElement(int[] nums)
    {
        var freq = new Dictionary<int, int>();

        foreach (var n in nums)
        {
            if (!freq.ContainsKey(n)) freq[n] = 0;
            freq[n]++;
        }

        var max = 0;
        var maxNumber = -1;
        foreach (var entry in freq)
        {
            if (entry.Value > max)
            {
                max = entry.Value;
                maxNumber = entry.Key;
            }
        }

        return maxNumber;
    }

    // Time: O(n)
    // Space: O(1)
    public int MajorityElementBoyerMoore(int[] nums)
    {
        var count = 0;
        var candidate = 0;

        foreach (var n in nums)
        {
            if (count == 0)
            {
                candidate = n;
            }

            count += n == candidate ? 1 : -1;
        }

        return candidate;
    }
}