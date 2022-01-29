public class RegularExpressionMatchingSolution
{
    enum Result { None, True, False }

    public bool IsMatch(string s, string p)
    {
        var cache = new Result[s.Length + 1, p.Length + 1];

        return helper(0, 0, s, p);

        bool helper(int i, int j, string s, string p)
        {
            if (cache[i, j] != Result.None) return cache[i, j] == Result.True;

            var result = false;
            if (j == p.Length) { result = (i == s.Length); }
            else
            {
                var match = i < s.Length && (p[j] == s[i] || p[j] == '.');

                // Look ahead on the next char in pattern.
                if (j + 1 < p.Length && p[j + 1] == '*')
                { // Wildcard
                    result = helper(i, j + 2, s, p) || (match && helper(i + 1, j, s, p));
                }
                else
                {
                    result = match && helper(i + 1, j + 1, s, p);
                }
            }
            cache[i, j] = result ? Result.True : Result.False;

            return result;
        }
    }
}