// https://leetcode.com/problems/k-diff-pairs-in-an-array/
public class KDiffPairsInArraySolution
{
    public int FindPairs(int[] nums, int k)
    {
        if (k < 0) return 0;

        var map = new Dictionary<int, int>();

        var count = 0;
        foreach (var n in nums)
        {
            if (map.ContainsKey(n))
            {
                if (k == 0 && map[n] == 1) count++;
                map[n]++;
            }
            else
            {
                if (map.ContainsKey(n - k)) count++;
                if (map.ContainsKey(n + k)) count++;
                map[n] = 1;
            }
        }

        return count;
    }
}