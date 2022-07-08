# https://leetcode.com/problems/insertion-sort-list/

from typing import Optional

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class Solution:
    def insertionSortList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        p = sentinel = ListNode()
        current = sentinel.next = head

        while current and current.next:
            if current.val <= current.next.val:
                current = current.next
                continue

            if p.next.val > current.next.val:
                p = sentinel # Start from the beginning

            while p.next.val <= current.next.val:
                p = p.next

            p.next, current.next.next, current.next = current.next, p.next, current.next.next

        return sentinel.next
