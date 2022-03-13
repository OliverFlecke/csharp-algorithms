// https://leetcode.com/problems/count-primes/
public class CountPrimesSolution
{
    public int CountPrimes(int n)
    {
        var notPrime = new bool[n];
        var count = 0;

        for (int i = 2; i < n; i++)
        {
            if (!notPrime[i])
            {
                count++;
                for (int j = 2; i * j < n; j++)
                {
                    notPrime[i * j] = true;
                }
            }
        }

        return count;
    }
}