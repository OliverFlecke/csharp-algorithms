// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
public class MaxProfitSolution
{
    public int MaxProfit(int[] prices)
    {
        var max = 0;
        var current = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            current = Math.Max(0, current + prices[i] - prices[i - 1]);
            max = Math.Max(max, current);
        }

        return max;
    }
}