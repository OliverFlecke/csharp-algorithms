// https://leetcode.com/problems/combination-sum/

public class CombinationSumSolution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        return FindSolutions(target, new List<int>(), 0).ToList();

        IEnumerable<IList<int>> FindSolutions(int target, List<int> choices, int start)
        {
            if (target == 0)
            {
                yield return choices;
                yield break;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                var newTarget = target - candidates[i];
                if (newTarget < 0) continue;

                var c = new List<int>();
                c.AddRange(choices);
                c.Add(candidates[i]);
                foreach (var solution in FindSolutions(newTarget, c, i))
                {
                    yield return solution;
                }
            }
        }
    }

    // https://leetcode.com/problems/combination-sum-ii/
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);

        var results = new List<IList<int>>();
        var choices = new Stack<int>();
        var sum = 0;

        FindChoices(0);

        return results;

        void FindChoices(int index)
        {
            if (sum == target) results.Add(choices.Reverse().ToList());
            if (sum >= target) return;

            for (int i = index; i < candidates.Length; i++)
            {
                if (i > index && candidates[i] == candidates[i - 1]) continue;

                sum += candidates[i];
                choices.Push(candidates[i]);

                FindChoices(i + 1);

                sum -= candidates[i];
                choices.Pop();
            }
        }
    }
}