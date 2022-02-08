public class HappyNumberSolution
{
    public bool IsHappy(int n)
    {
        var s = new HashSet<int>();

        do
        {
            s.Add(n);
            n = Next(n);
        } while (n != 1 && !s.Contains(n));

        return n == 1;
    }

    private int Next(int n)
    {
        var result = 0;

        while (n > 0)
        {
            var digit = n % 10;
            result += digit * digit;
            n /= 10;
        }

        return result;
    }

    // https://leetcode.com/problems/ugly-number/
    public bool IsUgly(int n)
    {
        if (n <= 0) return false;

        var factors = new int[] { 2, 3, 5 };

        foreach (var factor in factors)
        {
            while (n % factor == 0)
            {
                n /= factor;
            }
        }

        return n == 1;
    }
}