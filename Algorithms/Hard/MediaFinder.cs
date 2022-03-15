// https://leetcode.com/problems/find-median-from-data-stream/
public class MedianFinder
{

    private PriorityQueue<int, int> small = new PriorityQueue<int, int>();
    private PriorityQueue<int, int> large = new PriorityQueue<int, int>();
    private bool even = true;

    public void AddNum(int num)
    {
        if (even)
        {
            large.Enqueue(num, num);
            var element = large.Dequeue();
            small.Enqueue(element, -element);
        }
        else
        {
            small.Enqueue(num, -num);
            var element = small.Dequeue();
            large.Enqueue(element, element);
        }

        even = !even;
    }

    public double FindMedian()
    {
        return even ? (small.Peek() + large.Peek()) / 2.0 : small.Peek();
    }
}
