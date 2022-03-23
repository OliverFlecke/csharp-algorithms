// https://leetcode.com/problems/evaluate-reverse-polish-notation/
public class EvalRPNSolution
{
    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int i))
            {
                stack.Push(i);
            }
            else // Token is an operator
            {
                int b = stack.Pop();
                int a = stack.Pop();

                int result = token switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                };
                stack.Push(result);
            }
        }

        return stack.Pop();
    }
}