class Solution:
    def findComplement(self, num: int) -> int:
        mask = int('1' * len('{0:b}'.format(num)), 2)
        return num ^ mask