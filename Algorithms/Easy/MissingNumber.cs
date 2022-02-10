public class MissingNumberSolution
{
    public int MissingNumber(int[] nums)
    {
        var r = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            r = r ^ i ^ nums[i];
        }

        return r ^ nums.Length;
    }
}