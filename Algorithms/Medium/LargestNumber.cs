// https://leetcode.com/problems/largest-number/
public class LargerNumberSolution
{
    class LargerNumberComparator : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            return string.Compare(a + b, b + a);
        }
    }

    public string LargestNumber(int[] nums)
    {
        var numbersAsStrings = nums
            .Select(x => x.ToString())
            .OrderByDescending(x => x, new LargerNumberComparator())
            .ToList();

        if (numbersAsStrings[0] == "0") return "0";

        return string.Join("", numbersAsStrings);
    }
}