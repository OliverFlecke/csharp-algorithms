// https://leetcode.com/problems/sliding-window-median/
public class MedianSlidingWindowSolution
{
    PriorityQueue<int, int> min = new PriorityQueue<int, int>();
    PriorityQueue<int, int> max = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

    public double[] MedianSlidingWindow(int[] nums, int k)
    {
        var results = new double[nums.Length - k + 1];
        for (int left = 0, right = 0; right < nums.Length; right++)
        {
            AddNum(nums[right]);
            if (right - left + 1 == k)
            {
                results[right - k + 1] = FindMedian();
                Remove(nums[left]);
                left++;
            }
        }

        return results;
    }

    void Balance()
    {
        if (min.Count == max.Count) return;

        if (max.Count > min.Count + 1)
        {
            int peek = max.Dequeue();
            min.Enqueue(peek, peek);
        }
        else if (max.Count < min.Count)
        {
            int peek = min.Dequeue();
            max.Enqueue(peek, peek);
        }
    }

    void AddNum(int num)
    {
        if (max.Count == 0 || max.Peek() >= num) max.Enqueue(num, num);
        else min.Enqueue(num, num);

        Balance();
    }

    void Remove(int num)
    {
        if (num > max.Peek()) Remove(min, num);
        else Remove(max, num);
        Balance();
    }

    void Remove(PriorityQueue<int, int> heap, int num)
    {
        var buffer = new List<int>();
        while (heap.Count > 0 && heap.Peek() != num)
            buffer.Add(heap.Dequeue());

        heap.Dequeue();
        foreach (var n in buffer) heap.Enqueue(n, n);
    }

    double FindMedian()
    {
        return max.Count > min.Count
            ? max.Peek()
            : min.Peek() / 2.0 + max.Peek() / 2.0;
    }
}