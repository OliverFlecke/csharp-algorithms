public class NumberOfIslandsSolution
{
    public int NumIslands(char[][] grid)
    {
        var count = 0;

        for (int x = 0; x < grid.Length; x++)
        {
            for (int y = 0; y < grid[x].Length; y++)
            {
                if (grid[x][y] == '1')
                {
                    DFS(x, y);
                    count++;
                }
            }
        }

        return count;

        void DFS(int x, int y)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[x].Length || grid[x][y] != '1') return;

            grid[x][y] = '#';

            DFS(x + 1, y);
            DFS(x - 1, y);
            DFS(x, y + 1);
            DFS(x, y - 1);
        }
    }
}