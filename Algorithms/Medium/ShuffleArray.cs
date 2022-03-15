// https://leetcode.com/problems/shuffle-an-array/
public class ShuffleArraySolution
{
    private int[] original;
    private Random rand = new Random();

    public Solution(int[] nums)
    {
        original = nums;
    }

    public int[] Reset()
    {
        return original;
    }

    public int[] Shuffle()
    {
        int[] array = (int[])original.Clone();

        for (int i = 0; i < array.Length; i++)
        {
            Swap(array, i, rand.Next(i, array.Length));
        }

        return array;
    }

    private void Swap(int[] array, int i, int j)
    {
        int tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }
}
