public class BinaryWatchSolution
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        var result = new List<string>();
        for (int minute = 0; minute < 60; minute++)
        {
            for (int hour = 0; hour < 12; hour++)
            {
                if (CountBits((minute << 5) | hour) == turnedOn)
                {
                    result.Add($"{hour}:{minute.ToString().PadLeft(2, '0')}");
                }
            }
        }

        return result;
    }

    int CountBits(int n)
    {
        var count = 0;

        while (n > 0)
        {
            if (n % 2 == 1) count++;
            n >>= 1;
        }

        return count;
    }
}