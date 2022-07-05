class Solution:
    def findContentChildren(self, g: List[int], s: List[int]) -> int:
        g = sorted(g)
        s = sorted(s)

        amount = 0
        j = 0
        for i in range(len(g)):
            while j < len(s) and g[i] > s[j]:
                j += 1

            if j >= len(s): break

            if g[i] <= s[j]:
                amount += 1
                j += 1

        return amount