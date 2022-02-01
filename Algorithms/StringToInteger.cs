// https://leetcode.com/problems/string-to-integer-atoi/

public class StringToIntegerSolution
{
    public int MyAtoi(string s)
    {
        int index = 0;
        while (index < s.Length && s[index] == ' ') index++;

        if (index == s.Length) return 0;

        int sign = 1;
        if (s[index] == '-')
        {
            sign = -1;
            index++;
        }
        else if (s[index] == '+') index++;

        ulong sum = 0;
        while (index < s.Length && IsDigit(s[index]))
        {
            var digit = s[index] - '0';
            sum = sum * 10 + (ulong)digit;

            if (sum > int.MaxValue) return sign == 1 ? int.MaxValue : int.MinValue;

            index++;
        }

        return (int)sum * sign;
    }

    private bool IsDigit(char c)
    {
        return '0' <= c && c <= '9';
    }
}