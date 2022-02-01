// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
public class RemoveNthNodeFromEndSolution
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        if (n == 0) return head.next;

        var length = 1;
        var current = head;

        while (current.next != null)
        {
            length++;
            current = current.next;
        }

        if (length == n) return head.next;

        current = head;
        var k = length - 1 - n;
        while (k > 0 && current is not null)
        {
            current = current.next;
            k--;
        }

        if (current is not null && current.next is not null)
            current.next = current.next.next;

        return head;
    }

    public ListNode? SwapNodes(ListNode head, int k)
    {
        if (head is null) return null;

        var fast = head;
        var slow = head;

        for (int i = 0; i < k - 1; i++) fast = fast?.next;

        var first = fast;

        while (fast?.next is not null)
        {
            fast = fast.next;
            slow = slow?.next;
        }

        Swap(first, slow);

        return head;

        void Swap(ListNode a, ListNode b)
        {
            var temp = a.val;
            a.val = b.val;
            b.val = temp;
        }
    }

}