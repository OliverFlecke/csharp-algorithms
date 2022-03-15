// https://leetcode.com/problems/find-the-duplicate-number/
public class FindDuplicateSolution
{
    public int FindDuplicate(int[] nums)
    {
        int fast = nums[0], slow = nums[0];

        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (fast != slow);

        slow = nums[0];
        while (fast != slow)
        {
            fast = nums[fast];
            slow = nums[slow];
        }

        return fast;
    }
}