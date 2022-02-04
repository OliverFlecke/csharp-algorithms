// https://leetcode.com/problems/single-number/submissions/
public class SingleNumberSolution
{
    // XOR => x ^ x = 0
    public int SingleNumber(int[] nums)
    {
        var sum = 0;

        foreach (var value in nums) sum ^= value;

        return sum;
    }
}