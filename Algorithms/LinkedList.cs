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

    // https://leetcode.com/problems/merge-k-sorted-lists/
    public ListNode? MergeKLists(ListNode[] lists)
    {
        ListNode? head = null;
        ListNode? current = head;

        var node = GetNextMin(lists);
        while (node is not null)
        {
            if (head is null)
            {
                head = node;
                current = head;
            }
            else
            {
                current.next = node;
                current = current.next;
            }

            node = GetNextMin(lists);
        }

        return head;

        ListNode? GetNextMin(ListNode[] lists)
        {
            int min = int.MaxValue;
            int index = -1;

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] is not null && lists[i].val < min)
                {
                    min = lists[i].val;
                    index = i;
                }
            }

            if (index == -1) return null;

            var node = lists[index];
            lists[index] = lists[index].next;

            return node;
        }
    }

    // https://leetcode.com/problems/remove-linked-list-elements/
    public ListNode? RemoveElements(ListNode? head, int val)
    {
        if (head is null) return null;

        head.next = RemoveElements(head.next, val);
        return head.val == val ? head.next : head;
    }

    public ListNode RemoveElementsIterative(ListNode head, int val)
    {
        var helper = new ListNode();
        var current = helper;
        helper.next = head;

        while (current.next is not null)
        {
            if (current.next.val == val) current.next = current.next.next;
            else current = current.next;
        }

        return helper.next;
    }

    // https://leetcode.com/problems/reverse-linked-list/
    public ListNode? ReverseList(ListNode? head)
    {
        ListNode? prev = null;
        while (head is not null)
        {
            var n = head.next;
            head.next = prev;
            prev = head;
            head = n;
        }

        return prev;
    }

    // https://leetcode.com/problems/delete-node-in-a-linked-list/
    public void DeleteNode(ListNode node)
    {
        while (node?.next?.next is not null)
        {
            node.val = node.next.val;
            node = node.next;
        }

        node.val = node.next.val;
        node.next = null;
    }

    // https://leetcode.com/problems/palindrome-linked-list/
    public bool IsPalindrome(ListNode head)
    {
        var slow = head;
        var fast = head;
        while (fast?.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        if (fast is not null) slow = slow.next;

        fast = head;
        slow = Reverse(slow);
        while (slow is not null)
        {
            if (fast.val != slow.val) return false;
            fast = fast.next;
            slow = slow.next;
        }

        return true;

        ListNode Reverse(ListNode node)
        {
            ListNode? prev = null;
            while (node is not null)
            {
                var next = node.next;
                node.next = prev;
                prev = node;
                node = next;
            }
            return prev;
        }
    }

    // https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
    public ListNode DeleteDuplicates(ListNode head)
    {
        var sentinel = new ListNode(-1, head);
        var predecessor = sentinel;

        while (head is not null)
        {
            if (head.next is not null && head.val == head.next.val)
            {
                while (head.next is not null && head.val == head.next.val)
                {
                    head = head.next;
                }

                predecessor.next = head.next;
            }
            else
            {
                predecessor = predecessor.next;
            }

            head = head.next;
        }

        return sentinel.next;
    }

    // https://leetcode.com/problems/add-two-numbers/
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var sentinel = new ListNode(0);
        var current = sentinel;

        var carry = 0;
        while (l1 is not null || l2 is not null)
        {
            var x = l1 is not null ? l1.val : 0;
            var y = l2 is not null ? l2.val : 0;

            var sum = carry + x + y;
            carry = sum / 10;
            current.next = new ListNode(sum % 10);
            current = current.next;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        if (carry > 0) current.next = new ListNode(carry);

        return sentinel.next;
    }

    // https://leetcode.com/problems/rotate-list/
    public ListNode? RotateRight(ListNode? head, int k)
    {
        if (head?.next is null) return head;

        ListNode? sentinel = new(0, head);
        int length = 0;
        var fast = sentinel;
        var slow = sentinel;
        while (fast.next is not null)
        {
            fast = fast.next;
            length++;
        }

        k = length - k % length;
        for (int j = k; j > 0; j--)
        {
            slow = slow?.next;
        }

        fast.next = sentinel.next;
        sentinel.next = slow?.next;
        if (slow is not null) slow.next = null;

        return sentinel.next;
    }
}