// https://leetcode.com/problems/longest-valid-parentheses/

public class LongestValidParenthesesSolution
{
    public int LongestValidParentheses(string s)
    {
        var max = 0;
        var cache = new int[s.Length];

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == ')') // If not a closing parentheses, a valid string does not end here
            {
                // Ending is '()'
                if (s[i - 1] == '(')
                {
                    // If the previous index is an opening parentheses, the end of the current substring is '()'. Hence the valid string is equal to the result at i - 2 plus the length of '()'
                    cache[i] = 2 + (i >= 2 ? cache[i - 2] : 0);
                }
                // Ending is '))' => Check if char at index i - cache[i - 1] - 1 is '(', hence substring is wrapped in '(...)'
                else if (i - cache[i - 1] > 0 && s[i - cache[i - 1] - 1] == '(')
                {
                    var previous = (i - cache[i - 1]) >= 2 ? cache[i - cache[i - 1] - 2] : 0;
                    cache[i] = cache[i - 1] + 2 + previous;
                }

                max = Math.Max(max, cache[i]);
            }
        }

        return max;
    }
}