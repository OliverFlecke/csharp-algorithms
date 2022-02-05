// https://leetcode.com/problems/min-stack/

#nullable enable
public class MinStack
{
    private Node? head;

    public void Push(int val)
    {
        if (head is null) head = new Node(val, val);
        else head = new Node(val, Math.Min(val, head.Min), head);
    }

    public void Pop()
    {
        head = head?.Next;
    }

    public int Top()
    {
        return head.Value;
    }

    public int GetMin()
    {
        return head.Min;
    }

    class Node
    {
        public int Value { get; }
        public int Min { get; }
        public Node? Next { get; }

        public Node(int value, int min, Node? next = null)
        {
            this.Value = value;
            this.Min = min;
            this.Next = next;
        }
    }
}
