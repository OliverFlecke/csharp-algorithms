public class NumberTheorySolutions
{
    // https://leetcode.com/problems/valid-perfect-square/
    // Time: O(sqrt(n))
    public bool IsPerfectSquare(int num)
    {
        var i = 1;
        while (num > 0)
        {
            num -= i;
            i += 2;
        }

        return num == 0;
    }

    // Time: O(lg(n))
    public bool IsPerfectSquare_BinarySearch(int num)
    {
        var low = 1;
        var high = num;

        while (low <= high)
        {
            long mid = (high + low) >> 1;

            long squared = mid * mid;
            if (squared == num) return true;
            else if (squared < num) low = (int)mid + 1;
            else high = (int)mid - 1;
        }

        return false;
    }
}