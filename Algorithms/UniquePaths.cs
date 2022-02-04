// https://leetcode.com/problems/unique-paths/

// Time: O(n * m)
// Space: O(n)

public class UniquePathsSolution
{
    public int UniquePaths(int m, int n)
    {
        var current = new int[n];
        var prev = new int[n];

        for (int y = 0; y < m; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (y == 0 && x == 0) current[x] = 1;
                else
                {
                    current[x] =
                        (y == 0 ? 0 : prev[x]) +
                        (x == 0 ? 0 : current[x - 1]);
                }
            }

            prev = current;
        }

        return current[n - 1];
    }

    // https://leetcode.com/problems/unique-paths-ii/
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var n = obstacleGrid.Length;
        var m = obstacleGrid[0].Length;
        var current = new int[n];
        var prev = new int[n];

        for (int y = 0; y < m; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (obstacleGrid[x][y] == 1) current[x] = 0;
                else if (y == 0 && x == 0) current[x] = 1;
                else
                {
                    current[x] =
                        (y == 0 ? 0 : prev[x]) +
                        (x == 0 ? 0 : current[x - 1]);
                }
            }

            prev = current;
        }

        return current[n - 1];
    }
}