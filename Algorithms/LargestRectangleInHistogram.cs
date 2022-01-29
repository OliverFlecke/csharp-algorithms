// Leetcode: https://leetcode.com/problems/largest-rectangle-in-histogram/

public class LargsetRectangeInHistogramSolution
{
    public int LargestRectangleArea(int[] heights)
    {
        if (heights == null || heights.Length == 0) return 0;

        var left = new int[heights.Length]; // Index of first lower point to the left
        var right = new int[heights.Length]; // Index of first lower point to the right
        right[heights.Length - 1] = heights.Length;
        left[0] = -1;

        // Find indexes of the lower points to the right. By caching the results and jumping to the previous point, we can get a O(n) runtime to find these. Example, if we have a strictly increasing order, the inner loop will never run. If they are decreasing order, for each iteration of the outer loop, the inner loop will look once, pointing to the index 0, and then jump to that. The opposite is true for the *right* case.
        for (int i = 1; i < heights.Length; i++)
        {
            var p = i - 1;

            while (p >= 0 && heights[p] >= heights[i])
            {
                p = left[p];
            }
            left[i] = p;
        }
        for (int i = heights.Length - 2; i >= 0; i--)
        {
            var p = i + 1;

            while (p < heights.Length && heights[p] >= heights[i])
            {
                p = right[p];
            }
            right[i] = p;
        }

        var max = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            max = Math.Max(max, heights[i] * (right[i] - left[i] - 1));
        }

        return max;
    }
}