public class WordBreakSolution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var words = new HashSet<string>(wordDict);
        var map = new bool[s.Length + 1];
        map[0] = true;

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (map[j] && words.Contains(s[j..i]))
                {
                    map[i] = true;
                    break;
                }
            }
        }

        return map[s.Length];
    }

    // https://leetcode.com/problems/word-break-ii/
    public IList<string> WordBreak2(string s, IList<string> wordDict)
    {
        var words = new HashSet<string>(wordDict);
        var result = new List<string>();

        Recurse(new List<string>(), 0, 0);

        return result;

        void Recurse(IList<string> current, int start, int end)
        {
            if (end == s.Length)
            {
                if (words.Contains(s[start..end]))
                {
                    current.Add(s[start..end]);
                    result.Add(string.Join(" ", current));
                }
                return;
            }

            if (words.Contains(s[start..end]))
            {
                var newList = new List<string>(current);
                newList.Add(s[start..end]);
                Recurse(newList, end, end + 1);
            }

            Recurse(current, start, end + 1);
        }
    }
}
