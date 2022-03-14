public class StringSolutions
{
    // https://leetcode.com/problems/reverse-string/
    public void ReverseString(char[] s)
    {
        for (int i = 0; i < s.Length / 2; i++)
        {
            var temp = s[i];
            s[i] = s[s.Length - i - 1];
            s[s.Length - i - 1] = temp;
        }
    }

    // https://leetcode.com/problems/isomorphic-strings/
    // Time: O(n) Space: O(1) english alphabet is fixed size
    public bool IsIsomorphic(string s, string t)
    {
        var map = new Dictionary<char, char>();
        var mapT2S = new Dictionary<char, char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (map.ContainsKey(s[i]) && map[s[i]] != t[i]) return false;
            if (mapT2S.ContainsKey(t[i]) && mapT2S[t[i]] != s[i]) return false;

            map[s[i]] = t[i];
            mapT2S[t[i]] = s[i];
        }

        return true;
    }

    // https://leetcode.com/problems/valid-anagram/
    public bool IsAnagram(string s, string t)
    {
        var freq = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (!freq.ContainsKey(c)) freq[c] = 0;
            freq[c]++;
        }

        foreach (var c in t)
        {
            if (!freq.ContainsKey(c)) return false;

            freq[c]--;
            if (freq[c] <= 0) freq.Remove(c);
        }

        return freq.Count == 0;
    }

    // https://leetcode.com/problems/word-pattern/
    public bool WordPattern(string pattern, string s)
    {
        var map = new Dictionary<char, string>();
        var wordToChar = new Dictionary<string, char>();

        var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (pattern.Length != words.Length) return false;

        for (int i = 0; i < pattern.Length; i++)
        {
            if (!map.ContainsKey(pattern[i])) map[pattern[i]] = words[i];
            else if (map[pattern[i]] != words[i]) return false;

            if (!wordToChar.ContainsKey(words[i])) wordToChar[words[i]] = pattern[i];
            else if (wordToChar[words[i]] != pattern[i]) return false;
        }

        return true;
    }

    // https://leetcode.com/problems/reverse-vowels-of-a-string/
    public string ReverseVowels(string s)
    {
        var left = 0;
        var right = s.Length - 1;
        var chars = s.ToCharArray();
        var vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        while (left < right)
        {
            if (vowels.Contains(s[left]) && vowels.Contains(s[right]))
            {
                Swap(chars, left, right);
                left++;
                right--;
            }
            else if (vowels.Contains(s[left])) right--;
            else left++;
        }

        return new string(chars);

        void Swap(char[] chars, int left, int right)
        {
            var temp = chars[left];
            chars[left] = chars[right];
            chars[right] = temp;
        }
    }

    // https://leetcode.com/problems/permutation-in-string/
    public bool CheckInclusion(string s1, string s2)
    {
        var original = new Dictionary<char, int>();
        foreach (var c in s1)
        {
            if (!original.ContainsKey(c)) original[c] = 0;
            original[c]++;
        }

        var freq = new Dictionary<char, int>(original);
        var i = 0;
        var start = 0;
        while (i < s2.Length)
        {
            var c = s2[i];
            if (freq.ContainsKey(c))
            {
                freq[c]--;
                if (freq[c] <= 0) freq.Remove(c);
                if (freq.Count == 0) return true;
            }
            else
            {
                freq = new Dictionary<char, int>(original);
                i = start;
                start++;
            }

            i++;
        }

        return false;
    }

    // https://leetcode.com/problems/valid-parentheses/
    public bool IsValidParentheses(string s)
    {
        var stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] is '(' or '{' or '[')
            {
                stack.Push(s[i]);
            }
            else if (stack.Count > 0 && Matches(stack.Peek(), s[i]))
            {
                stack.Pop();
            }
            else return false;
        }

        return stack.Count == 0;

        bool Matches(char left, char right) => (left, right) switch
        {
            ('(', ')') => true,
            ('{', '}') => true,
            ('[', ']') => true,
            _ => false,
        };
    }

    #region Medium
    // https://leetcode.com/problems/simplify-path/
    public string SimplifyPath(string path)
    {
        var sections = path.Replace("//", "/")
            .Split("/", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        int i = 0;
        while (i < sections.Count)
        {
            if (sections[i] == "..")
            {
                sections.RemoveAt(i);
                if (i > 0)
                {
                    sections.RemoveAt(i - 1);
                    i--;
                }
            }
            else if (sections[i] == ".")
            {
                sections.RemoveAt(i);
            }
            else i++;
        }

        return "/" + string.Join("/", sections);
    }
    #endregion
}