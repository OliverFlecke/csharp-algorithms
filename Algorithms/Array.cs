public class ArraySolution
{
    // https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
    public int RemoveDuplicates(int[] nums)
    {
        var k = 2;
        var i = 0;
        foreach (var n in nums)
        {
            if (i < k || n > nums[i - k])
            {
                nums[i++] = n;
            }
        }

        return i;
    }
}