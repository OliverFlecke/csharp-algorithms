# https://leetcode.com/problems/linked-list-cycle-ii/
from typing import Optional

# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution:
    def detectCycle(self, head: Optional[ListNode]) -> Optional[ListNode]:
        visited = set()

        while head:
            if head in visited: return head

            visited.add(head)
            head = head.next

        return None

    def detectCyclePointers(self, head: Optional[ListNode]) -> Optional[ListNode]:
        slow = fast = head

        while fast and fast.next:
            slow, fast = slow.next, fast.next.next
            if slow == fast: break

        if not (fast and fast.next): return None

        while head != slow:
            head, slow = head.next, slow.next

        return head