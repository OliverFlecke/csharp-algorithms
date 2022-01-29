// Leetcode: https://leetcode.com/problems/longest-increasing-path-in-a-matrix/

// Idea: Go through every cell in the matrix and perform DFS to calculate the path.
// Use cacheing to avoid having to recalculate paths for previous cells.

public class LongestIncreasingPathInAMatrixSolution
{
    private (int, int)[] directions = new (int, int)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

    public int LongestIncreasingPath(int[][] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0) return 0;

        var n = matrix.Length;
        var m = matrix[0].Length;
        int[,] cache = new int[n, m];
        var max = 1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                max = Math.Max(max, DFS(matrix, i, j, cache));
            }
        }

        return max;
    }

    public int DFS(int[][] matrix, int i, int j, int[,] cache)
    {
        if (cache[i, j] != 0) return cache[i, j];

        var n = matrix.Length;
        var m = matrix[0].Length;
        int max = 1;

        foreach (var (dx, dy) in directions)
        {
            var x = i + dx;
            var y = j + dy;

            if (x < 0 || x >= n || y < 0 || y >= m) continue; // Check bounds
            if (matrix[x][y] <= matrix[i][j]) continue; // Check path is increasing

            max = Math.Max(max, 1 + DFS(matrix, x, y, cache));
        }

        cache[i, j] = max;

        return max;
    }
}