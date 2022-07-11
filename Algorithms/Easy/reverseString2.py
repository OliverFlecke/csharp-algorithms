# https://leetcode.com/problems/reverse-string-ii/
class Solution:
    def reverseStr(self, s: str, k: int) -> str:
        array = list(s)
        for start in range(0, len(s), 2 * k):
            i, j = start, min(start + k - 1, len(s) - 1)
            while i < j:
                array[i], array[j] = array[j], array[i]
                i += 1
                j -= 1

        return ''.join(array)

    def reverseStrAlt(self, s: str, k: int) -> str:
        s = list(s)
        for i in range(0, len(s), 2*k): s[i:i+k] = s[i:i+k][::-1]
        return ''.join(s)