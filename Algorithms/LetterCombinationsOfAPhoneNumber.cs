// https://leetcode.com/problems/letter-combinations-of-a-phone-number/

public class LetterCombinationsOfAPhoneNumberSolution
{
    private readonly Dictionary<char, char[]> Mapping = new()
    {
        ['2'] = "abc".ToCharArray(),
        ['3'] = "def".ToCharArray(),
        ['4'] = "ghi".ToCharArray(),
        ['5'] = "jkl".ToCharArray(),
        ['6'] = "mno".ToCharArray(),
        ['7'] = "pqrs".ToCharArray(),
        ['8'] = "tuv".ToCharArray(),
        ['9'] = "wxyz".ToCharArray(),
    };

    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0) return new List<string>() { };

        var digit = digits[0];
        if (digits.Length == 1) return Mapping[digit].Select(x => x.ToString()).ToList();

        var result = new List<string>();
        foreach (var sub in LetterCombinations(digits.Substring(1)))
        {
            foreach (var letter in Mapping[digit])
            {
                result.Add(letter + sub);
            }
        }

        return result;
    }
}