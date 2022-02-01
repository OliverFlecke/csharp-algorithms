// https://leetcode.com/problems/powx-n/
public class PowerSolution
{
    public double MyPow(double x, int n)
    {
        if (n == 0) return 1;
        if (n == 1) return x;
        if (n == -1) return 1 / x;

        var half = MyPow(x, n / 2);
        var result = half * half;
        if (n % 2 is 1 or -1)
        {
            result = result * (n > 0 ? x : 1 / x);
        }
        return result;
    }
}