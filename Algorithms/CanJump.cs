// Leetcode: https://leetcode.com/problems/jump-game/

public class CanJumpSolution
{
    enum Result { None, True, False, }

    public bool CanJump(int[] nums)
    {
        var cache = new Result[nums.Length];
        cache[nums.Length - 1] = Result.True;

        return Helper(0);

        bool Helper(int index)
        {
            if (cache[index] != Result.None) return cache[index] == Result.True;

            var max = index + nums[index];
            var answer = false;
            for (int i = index + 1; i <= max && i < nums.Length; i++)
            {
                if (Helper(i))
                {
                    answer = true;
                    break;
                }
            }
            cache[index] = answer ? Result.True : Result.False;

            return answer;
        }
    }

    // https://leetcode.com/problems/jump-game-ii/
    public int Jump(int[] nums)
    {
        var cache = new int[nums.Length];
        for (int i = 0; i <= nums.Length - 2; i++)
        {
            cache[i] = int.MaxValue;
        }
        cache[nums.Length - 1] = 0;

        return Helper(0);

        int Helper(int index)
        {
            if (cache[index] != int.MaxValue) return cache[index];

            var max = index + nums[index];
            var min = int.MaxValue;
            for (int i = index + 1; i <= max && i < nums.Length; i++)
            {
                var cost = Helper(i);
                min = Math.Min(min, cost == int.MaxValue ? int.MaxValue : 1 + cost);
            }
            cache[index] = min;

            return min;
        }
    }

    // Leetcode: https://leetcode.com/problems/jump-game-iii/
    // Time: O(n) recurses once for each index
    // Space: O(n) for cache and stack space (in worst case)
    public class SolutionIII
    {
        enum Result { None, Visiting, True, False }

        public bool CanReach(int[] arr, int start)
        {
            var cache = new Result[arr.Length];

            return Helper(start);

            bool Helper(int index)
            {
                if (arr[index] == 0) return true;
                if (cache[index] != Result.None) return cache[index] == Result.True;

                cache[index] = Result.Visiting;
                var answer = false;
                var amount = arr[index];
                var left = index + amount;
                var right = index - amount;
                if (left < arr.Length)
                {
                    answer |= Helper(left);
                }
                if (!answer && right >= 0)
                {
                    answer |= Helper(right);
                }
                cache[index] = answer ? Result.True : Result.False;

                return answer;
            }
        }
    }

    public class SolutionVII
    {
        public bool CanReach(string s, int minJump, int maxJump)
        {
            var cache = new bool[s.Length];
            cache[0] = true;

            var hasTrueInWindow = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (i >= minJump && cache[i - minJump])
                {
                    hasTrueInWindow++;
                }
                if (i > maxJump && cache[i - maxJump - 1])
                {
                    hasTrueInWindow--;
                }

                cache[i] = hasTrueInWindow > 0 && s[i] == '0';
            }

            return cache[s.Length - 1];
        }
    }
}