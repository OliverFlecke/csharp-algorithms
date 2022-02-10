// https://leetcode.com/problems/fibonacci-number/
public class FibonacciNumberSolution
{
    public int Fib(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        var prev = 0;
        var cur = 1;

        var i = 1;
        while (i < n)
        {
            var tmp = cur;
            cur = prev + cur;
            prev = tmp;
            i++;
        }

        return cur;
    }
}