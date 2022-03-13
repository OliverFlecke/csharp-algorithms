// https://leetcode.com/problems/group-anagrams/
public class GroupAnagramsSolution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var result = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            var sorted = string.Concat(str.OrderBy(c => c));
            if (!result.ContainsKey(sorted)) result[sorted] = new List<string>();

            result[sorted].Add(str);
        }

        return result.Values.ToList();
    }
}