// https://leetcode.com/problems/add-digits/
public class AddDigitsSolution
{
    public int AddDigits(int num)
    {
        while (num >= 10)
        {
            var result = 0;
            while (num > 0)
            {
                result += num % 10;
                num /= 10;
            }

            num = result;
        }

        return num;
    }
}