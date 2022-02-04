// https://leetcode.com/problems/find-all-anagrams-in-a-string/

public class FindAnagramsSolution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        var results = new List<int>();
        if (p.Length > s.Length) return results;

        var freqs = new Dictionary<char, int>();
        foreach (var c in p)
        {
            if (!freqs.ContainsKey(c)) freqs.Add(c, 0);
            freqs[c]++;
        }

        var start = 0;
        var end = 0;
        var counter = freqs.Count;

        while (end < s.Length)
        {
            var c = s[end];
            if (freqs.ContainsKey(c))
            {
                freqs[c]--;
                if (freqs[c] == 0) counter--;
            }
            end++;

            while (start < s.Length && counter == 0)
            {
                char a = s[start];
                if (freqs.ContainsKey(a))
                {
                    freqs[a]++;
                    if (freqs[a] > 0) { counter++; }
                }

                if (end - start == p.Length)
                {
                    results.Add(start);
                }
                start++;
            }
        }

        return results;
    }
}