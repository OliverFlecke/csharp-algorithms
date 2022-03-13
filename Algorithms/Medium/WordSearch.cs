// https://leetcode.com/problems/word-search/
public class WordSearchSolution
{
    public bool Exist(char[][] board, string word)
    {
        var visited = new HashSet<(int, int)>();

        for (int x = 0; x < board.Length; x++)
        {
            for (int y = 0; y < board[x].Length; y++)
            {
                if (word[0] == board[x][y] && Search(x, y, 0)) return true;
            }
        }

        return false;

        bool Search(int x, int y, int index)
        {
            if (index == word.Length) return true;

            if (x >= board.Length || x < 0 || y >= board[x].Length || y < 0
                || board[x][y] != word[index] || visited.Contains((x, y)))
            {
                return false;
            }

            visited.Add((x, y));
            if (Search(x - 1, y, index + 1)
               || Search(x + 1, y, index + 1)
               || Search(x, y - 1, index + 1)
               || Search(x, y + 1, index + 1))
            {
                return true;
            }

            visited.Remove((x, y));
            return false;
        }
    }
}