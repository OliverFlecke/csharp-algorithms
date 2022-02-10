public class StackWithQueues
{
    Queue<int> queue = new();

    public void Push(int x)
    {
        queue.Enqueue(x);
        var size = queue.Count;
        while (size > 1)
        {
            queue.Enqueue(queue.Dequeue());
            size--;
        }
    }

    public int Pop()
    {
        return queue.Dequeue();
    }

    public int Top()
    {
        return queue.Peek();
    }

    public bool Empty()
    {
        return queue.Count == 0;
    }
}