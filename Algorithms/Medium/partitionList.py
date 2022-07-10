# https://leetcode.com/problems/partition-list/
from typing import Optional

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
class Solution:
    def partition(self, head: Optional[ListNode], x: int) -> Optional[ListNode]:
        before = beforeHead = ListNode(-1)
        after = afterHead = ListNode(-1)

        while head:
            if head.val < x:
                before.next = head
                before = before.next
            else:
                after.next = head
                after = after.next

            head = head.next

        before.next = afterHead.next
        after.next = None

        return beforeHead.next
