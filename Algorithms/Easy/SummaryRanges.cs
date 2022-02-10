// https://leetcode.com/problems/summary-ranges/
public class SummaryRangesSolution
{
    public IList<string> SummaryRanges(int[] nums)
    {
        var result = new List<string>();
        if (nums.Length == 0) return result;

        var start = 0;
        var end = 1;

        while (end < nums.Length)
        {
            if (nums[end] - nums[end - 1] != 1)
            {
                AddResult();

                start = end;
            }

            end++;
        }

        AddResult();

        return result;

        void AddResult()
        {
            if (start == end - 1) result.Add($"{nums[start]}");
            else result.Add($"{nums[start]}->{nums[end - 1]}");
        }
    }
}