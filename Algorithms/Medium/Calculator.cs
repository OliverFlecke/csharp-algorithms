// https://leetcode.com/problems/basic-calculator/
public class CalculatorSolution
{
    public int Calculate(string s)
    {
        int sign = 1, result = 0;
        var stack = new Stack<int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                int sum = s[i] - '0';
                while (i + 1 < s.Length && char.IsDigit(s[i + 1]))
                {
                    sum = 10 * sum + (s[i + 1] - '0');
                    i++;
                }

                result += sign * sum;
            }
            else if (s[i] == '+') sign = 1;
            else if (s[i] == '-') sign = -1;
            else if (s[i] == ')') result = stack.Pop() * result + stack.Pop();
            else if (s[i] == '(')
            {
                stack.Push(result);
                stack.Push(sign);
                result = 0;
                sign = 1;
            }
        }

        return result;
    }
}

// https://leetcode.com/problems/basic-calculator-ii/
public class Calculator2Solution
{
    public int Calculate(string s)
    {
        if (s is null || s.Length == 0) return 0;

        var stack = new Stack<int>();
        int current = 0;
        char op = '+';

        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];

            if (char.IsDigit(c)) current = (10 * current) + (c - '0');

            if (!char.IsDigit(c) && !char.IsWhiteSpace(c) || i == s.Length - 1)
            {
                if (op == '-') stack.Push(-current);
                else if (op == '+') stack.Push(current);
                else if (op == '*') stack.Push(stack.Pop() * current);
                else if (op == '/') stack.Push(stack.Pop() / current);

                op = c;
                current = 0;
            }
        }

        var result = 0;
        while (stack.Count > 0)
        {
            result += stack.Pop();
        }

        return result;
    }

    public int CalculateWithoutStack(string s)
    {
        if (s is null || s.Length == 0) return 0;

        int current = 0, last = 0, result = 0;
        char op = '+';

        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (char.IsDigit(c)) current = (10 * current) + (c - '0');

            if (!char.IsDigit(c) && !char.IsWhiteSpace(c) || i == s.Length - 1)
            {
                if (op == '+' || op == '-')
                {
                    result += last;
                    last = op == '+' ? current : -current;
                }
                else if (op == '*') last = last * current;
                else if (op == '/') last = last / current;

                op = c;
                current = 0;
            }
        }

        result += last;
        return result;
    }
}