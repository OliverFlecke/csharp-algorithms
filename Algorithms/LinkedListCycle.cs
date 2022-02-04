// https://leetcode.com/problems/linked-list-cycle/

public class LinkedListCylceSolution
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
    public bool HasCycle(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast?.next?.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (fast == slow) return true;
        }

        return false;
    }
}