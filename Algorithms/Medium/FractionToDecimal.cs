using System.Text;

public class FractionToDecimalSolution
{
    public string FractionToDecimal(int numerator, int denominator)
    {
        if (numerator == 0) return "0";

        var result = new StringBuilder();

        // Check for negative numbers
        if ((numerator > 0) ^ (denominator > 0)) result.Append('-');

        long num = Math.Abs((long)numerator);
        long den = Math.Abs((long)denominator);

        // Integral
        result.Append(num / den);
        num %= den;
        if (num == 0) return result.ToString();

        // Fraction
        result.Append('.');
        Dictionary<long, int> map = new();
        map[num] = result.Length;

        while (num != 0)
        {
            num *= 10;
            result.Append(num / den);
            num %= den;

            if (map.ContainsKey(num))
            {
                var index = map[num];
                result.Insert(index, '(');
                result.Append(')');
                break;
            }
            else
            {
                map[num] = result.Length;
            }
        }

        return result.ToString();
    }
}