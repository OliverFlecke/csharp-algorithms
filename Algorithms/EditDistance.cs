// https://leetcode.com/problems/edit-distance/

public class EditDistanceSolution
{
    public int MinDistance(string word1, string word2)
    {
        var cache = new int[word1.Length, word2.Length];
        return Helper(0, 0);

        int Helper(int i, int j)
        {
            if (i < word1.Length && j < word2.Length && cache[i, j] != 0) return cache[i, j];
            if (i == word1.Length) return word2.Length - j;
            if (j == word2.Length) return word1.Length - i;

            if (word1[i] == word2[j]) return Helper(i + 1, j + 1);

            var insert = 1 + Helper(i, j + 1);
            var deletion = 1 + Helper(i + 1, j);
            var replace = 1 + Helper(i + 1, j + 1);

            cache[i, j] = Math.Min(Math.Min(insert, deletion), replace);
            return cache[i, j];
        }
    }
}