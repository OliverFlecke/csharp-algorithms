// https://leetcode.com/problems/subsets/

public class SubsetSolution
{
    // The idea of this solution is originated from Donald E. Knuth.
    // The idea is that we map each subset to a bitmask of length n, where 1 on the ith position in bitmask means the presence of nums[i] in the subset, and 0 means its absence.
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();

        int size = (int)Math.Pow(2, nums.Length + 1);
        for (int i = (int)Math.Pow(2, nums.Length); i < size; ++i)
        {
            var bitmask = Convert.ToString(i, 2).Substring(1);

            var subset = new List<int>();
            for (int x = 0; x < nums.Length; x++)
            {
                if (bitmask[x] == '1') subset.Add(nums[x]);
            }
            result.Add(subset);
        }

        return result;
    }

    public IList<IList<int>> SubsetsKnuthWithoutString(int[] nums)
    {
        var result = new List<IList<int>>();

        int size = (int)Math.Pow(2, nums.Length);
        for (int i = 0; i < size; i++)
        {
            var subset = new List<int>();
            var n = i;
            var x = 0;
            while (n > 0)
            {
                if (n % 2 == 1) subset.Add(nums[x]);

                n /= 2;
                x++;
            }
            result.Add(subset);
        }

        return result;
    }


    // Solution with backtracking
    public IList<IList<int>> SubsetsBacktracking(int[] nums)
    {
        var result = new List<IList<int>>();

        for (int size = 0; size <= nums.Length; size++)
        {
            Backtrack(size, 0, new LinkedList<int>());
        }

        return result;

        void Backtrack(int size, int start, LinkedList<int> subset)
        {
            if (size == subset.Count)
            {
                result.Add(new List<int>(subset));
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                subset.AddLast(nums[i]);
                Backtrack(size, i + 1, subset);
                subset.RemoveLast();
            }
        }
    }
}