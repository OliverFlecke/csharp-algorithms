// https://leetcode.com/problems/implement-queue-using-stacks/
public class QueueWithStack
{
    Stack<int> front = new();
    Stack<int> back = new();

    public void Push(int x)
    {
        back.Push(x);
    }

    public int Pop()
    {
        Move();

        return front.Pop();
    }

    public int Peek()
    {
        Move();

        return front.Peek();
    }

    public bool Empty()
    {
        return front.Count == 0 && back.Count == 0;
    }

    void Move()
    {
        if (front.Count != 0) return;

        while (back.Count != 0)
        {
            front.Push(back.Pop());
        }
    }
}
