public class MoveZerosSolution
{
    public void MoveZeroes(int[] nums)
    {
        var lastIndex = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                if (lastIndex != i)
                {
                    var temp = nums[lastIndex];
                    nums[lastIndex] = nums[i];
                    nums[i] = temp;
                }
                lastIndex++;
            }
        }
    }
}