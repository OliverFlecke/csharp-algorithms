// https://leetcode.com/problems/sqrtx/
public class SqrtSolution
{
    public int MySqrt(int x)
    {
        if (x == 0) return 0;

        int left = 1;
        int right = x;
        while (true)
        {
            int n = (left + right) / 2;

            if (n > x / n) right = n - 1;
            else
            {
                if (n + 1 > x / (n + 1)) return n;
                left = n + 1;
            }
        }
    }

    // Example: 11
    // left = 1, right = 11
    //
    // 1.   n = 12 / 2 = 6
    //      n > x / n       => 6 > 11 / 6       => 6 > 1.88     => true
    //      right = n - 1   = 5
    //
    // 2.   n = (1 + 5) / 2 = 3
    //      n > x / n       => 3 > 11 / 3       => 3 > 3.666    => false so else branch
    //      n + 1 > x / (n + 1)     => 4 > 11 / 4      => 4 > 2.75      => true so return 3, because 3*3 = 9 and 4*4 = 16, which is too big

    // Newton's method
    public int MySqrt_Newton(int x)
    {
        long n = x;
        while (n * n > x)
        {
            n = (n + x / n) / 2;
        }

        return (int)n;
    }
}