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
}