public class FindTheDifferenceSolution
{
    public char FindTheDifference(string s, string t)
    {
        var map = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (!map.ContainsKey(c)) map[c] = 0;
            map[c]++;
        }

        foreach (var c in t)
        {
            if (!map.ContainsKey(c) || --map[c] < 0) return c;
        }

        return '0';
    }
}