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

    // https://leetcode.com/problems/power-of-two/
    public bool IsPowerOfTwo(int n)
    {
        return n > 0 && (n & (n - 1)) == 0;
    }

    // https://leetcode.com/problems/power-of-three/
    public bool IsPowerOfThree(int n)
    {
        return (Math.Log10(n) / Math.Log10(3) + double.Epsilon) % 1 <= 2 * double.Epsilon;
    }

    // https://leetcode.com/problems/power-of-four/
    public bool IsPowerOfFour(int n)
    {
        return (Math.Log10(n) / Math.Log10(4) + double.Epsilon) % 1 <= 2 * double.Epsilon;
    }
}