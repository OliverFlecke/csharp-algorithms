// https://leetcode.com/problems/subarray-sum-equals-k/
public class SubarryKEqualsSolution
{
    public int SubarraySum(int[] nums, int k)
    {
        var count = 0;
        var sum = 0;

        var map = new Dictionary<int, int>();
        map[0] = 1;

        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (map.ContainsKey(sum - k)) count += map[sum - k];

            if (!map.ContainsKey(sum)) map[sum] = 0;
            map[sum]++;
        }

        return count;
    }
}