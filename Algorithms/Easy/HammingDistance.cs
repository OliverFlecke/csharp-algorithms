public class HammingDistanceSolution
{
    // https://leetcode.com/problems/hamming-distance/
    public int HammingDistance(int x, int y)
    {
        var n = x ^ y;
        var count = 0;
        while (n > 0)
        {
            if (n % 2 == 1) count++;
            n >>= 1;
        }

        return count;
    }
}