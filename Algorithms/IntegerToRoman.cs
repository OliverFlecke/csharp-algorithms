// https://leetcode.com/problems/integer-to-roman/

using System.Text;

public class IntegerToRomanSolution
{
    public string IntToRoman(int num)
    {
        var builder = new StringBuilder();

        var items = new List<(string, int)>()
        {
            ("M", 1000),
            ("CM", 900),
            ("D", 500),
            ("CD", 400),
            ("C", 100),
            ("XC", 90),
            ("L", 50),
            ("XL", 40),
            ("X", 10),
            ("IX", 9),
            ("V", 5),
            ("IV", 4),
            ("I", 1),
        };

        int i = 0;
        while (num > 0)
        {
            var (c, value) = items[i];
            while (num >= value)
            {
                num -= value;
                builder.Append(c);
            }
            i++;
        }

        return builder.ToString();
    }
}