class Solution:
    def longestPalindrome(self, s: str) -> int:
        d = {}
        for c in s:
            if c not in d: d[c] = 0
            d[c] += 1

        ans = 0
        for v in d.values():
            ans += v // 2 * 2
            if ans % 2 == 0 and v % 2 == 1:
                ans += 1
        return ans