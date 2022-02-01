// https://leetcode.com/problems/sudoku-solver/

public class SodokuSolverSolution
{
    public void SolveSudoku(char[][] board)
    {
        Solve(board);
    }

    private bool Solve(char[][] board)
    {
        for (int x = 0; x < board.Length; x++)
        {
            for (int y = 0; y < board[0].Length; y++)
            {
                if (board[x][y] == '.')
                {
                    for (char c = '1'; c <= '9'; c++)
                    {
                        if (IsValid(board, x, y, c))
                        {
                            board[x][y] = c;

                            // Recurse
                            if (Solve(board)) return true;
                            else board[x][y] = '.'; // Unable to solve with this configuration
                        }
                    }

                    return false;
                }
            }
        }

        return true;
    }

    private bool IsValid(char[][] board, int x, int y, char c)
    {
        var blockRow = (x / 3) * 3;
        var blockCol = (y / 3) * 3;

        for (int i = 0; i < 9; i++)
        {
            if (board[i][y] == c) return false;
            if (board[x][i] == c) return false;
            if (board[blockRow + i / 3][blockCol + i % 3] == c) return false;
        }

        return true;
    }

    // https://leetcode.com/problems/valid-sudoku/
    public bool IsValidSudoku(char[][] board)
    {
        var s = new HashSet<string>();

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var c = board[i][j];

                if (c == '.') continue;

                if (!s.Add($"{c}r{i}") ||
                    !s.Add($"{c}c{j}") ||
                    !s.Add($"{c}b{i / 3}-{j / 3}"))
                {
                    return false;
                }
            }
        }

        return true;
    }
}