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
}