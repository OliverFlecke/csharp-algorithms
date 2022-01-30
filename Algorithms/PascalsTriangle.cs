// Leetcode: https://leetcode.com/problems/pascals-triangle/

public class PascalsTriangleSolution
{
    public IList<IList<int>> Generate(int numRows)
    {
        if (numRows == 0) return new List<IList<int>>();

        var result = new List<IList<int>> { new int[] { 1 } };

        for (int r = 1; r < numRows; r++)
        {
            var prev = result[r - 1];
            var row = new List<int> { 1 };

            for (int x = 1; x < r; x++)
            {
                row.Add(prev[x - 1] + prev[x]);
            }

            row.Add(1);
            result.Add(row);
        }

        return result;
    }
}

public class PascalsTriangleIISolution
{
    public IList<int> GetRow(int rowIndex)
    {
        var prev = new List<int> { 1 };
        var row = prev;

        for (int r = 1; r <= rowIndex; r++)
        {
            row = new List<int> { 1 };

            for (int x = 1; x < r; x++)
            {
                row.Add(prev[x - 1] + prev[x]);
            }

            row.Add(1);
            prev = row;
        }

        return row;
    }
}