// https://leetcode.com/problems/gas-station/
public class CanCompleteCircuitSolution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int n = gas.Length;
        int total = 0;
        int tank = 0;
        int start = 0;

        for (int i = 0; i < n; i++)
        {
            total += gas[i] - cost[i];
            tank += gas[i] - cost[i];

            if (tank < 0)
            {
                tank = 0;
                start = i + 1;
            }
        }

        return total < 0 ? -1 : start;
    }
}