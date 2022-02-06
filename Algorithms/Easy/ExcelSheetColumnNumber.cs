using System.Text;

// https://leetcode.com/problems/excel-sheet-column-title/
public class ExcelSheetColumnNumberSolution
{
    // Recursive
    public string ConvertToTitle(int columnNumber)
    {
        if (columnNumber == 0) return "";

        return ConvertToTitle((columnNumber - 1) / 26)
            + ((char)('A' + (columnNumber - 1) % 26));
    }

    public string ConvertToTitleIterative(int n)
    {
        var result = new StringBuilder();

        while (n > 0)
        {
            n--;
            result.Insert(0, (char)('A' + n % 26));
            n /= 26;
        }

        return result.ToString();
    }

    public int TitleToNumber(string title)
    {
        var result = 0;

        foreach (var c in title)
            result = result * 26 + c - 'A' + 1;

        return result;
    }
}