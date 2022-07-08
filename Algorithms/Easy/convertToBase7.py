class Solution:
    def convertToBase7(self, num: int) -> str:
        n, result = abs(num), ''

        while n:
            result = str(n % 7) + result
            n = n // 7

        if not result: return "0"

        return result if num >= 0 else '-' + result