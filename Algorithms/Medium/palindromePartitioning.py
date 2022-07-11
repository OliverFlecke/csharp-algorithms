# https://leetcode.com/problems/palindrome-partitioning/
from typing import List

class Solution:
    def partition(self, s: str) -> List[List[str]]:
        def isPalindrome(start: int, end: int) -> bool:
            first, last = start, end
            while first < last:
                if s[first] == s[last]:
                    first += 1
                    last -= 1
                else: return False

            return True

        result = []
        def dfs(start: int, current: List[str]):
            if start >= len(s): result.append(current)

            for end in range(start, len(s)):
                if isPalindrome(start, end):
                    dfs(end + 1, current + [s[start:end + 1]])

        dfs(0, [])
        return result


