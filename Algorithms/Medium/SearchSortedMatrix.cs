// https://leetcode.com/problems/search-a-2d-matrix-ii/
public class SearchSortedMatrixSolution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix is null || matrix.Length <= 0 || matrix[0].Length <= 0) return false;

        int col = matrix[0].Length - 1;
        int row = 0;

        while (col >= 0 && row <= matrix.Length - 1)
        {
            if (target == matrix[row][col]) return true;
            else if (target < matrix[row][col]) col--;
            else if (target > matrix[row][col]) row++;
        }

        return false;
    }
}