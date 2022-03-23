// https://leetcode.com/problems/minimum-window-substring/
public class MinimumWindowSubstringSolution
{
    public string MinWindow(string s, string t)
    {
        if (s is null || s.Length == 0 || t is null || t.Length == 0) return "";

        Dictionary<char, int> dict = new();
        foreach (var c in t)
        {
            dict[c] = 1 + dict.GetValueOrDefault(c, 0);
        }

        int formed = 0;
        int left = 0, right = 0;
        Dictionary<char, int> window = new();

        (int Length, int Left, int Right) answer = (-1, 0, 0);

        while (right < s.Length)
        {
            var c = s[right];
            window[c] = 1 + window.GetValueOrDefault(c, 0);

            if (dict.ContainsKey(c) && window[c] == dict[c]) formed++;

            while (left <= right && formed == dict.Count)
            {
                c = s[left];
                if (answer.Length == -1 || right - left + 1 < answer.Length)
                {
                    answer = (right - left + 1, left, right);
                }

                window[c]--;
                if (dict.ContainsKey(c) && window[c] < dict[c]) formed--;

                left++;
            }

            right++;
        }

        return answer.Length == -1
            ? ""
            : s.Substring(answer.Left, answer.Length);
    }
}