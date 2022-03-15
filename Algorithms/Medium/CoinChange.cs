// https://leetcode.com/problems/coin-change/
public class CoinChangeSolution
{
    public int CoinChange(int[] coins, int amount)
    {
        var cache = new int[amount + 1];
        Array.Fill(cache, amount + 1);
        cache[0] = 0;

        for (int i = 1; i < cache.Length; i++)
        {
            // Console.WriteLine($"{i}: {string.Join(", ", cache)}");
            foreach (int coin in coins)
            {
                if (i >= coin)
                {
                    // Console.WriteLine($"Updating {coin}: prev: {cache[i - coin] + 1} cur: {cache[i]}");
                    cache[i] = Math.Min(cache[i - coin] + 1, cache[i]);
                }
            }
        }
        // Console.WriteLine(string.Join(", ", cache));
        return cache[amount] == amount + 1 ? -1 : cache[amount];
    }
}