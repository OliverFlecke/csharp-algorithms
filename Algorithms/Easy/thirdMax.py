class Solution:
    def thirdMax(self, nums: List[int]) -> int:
        values = [float('-inf'), float('-inf'), float('-inf')]

        for n in nums:
            for i in range(3):
                if n == values[i]: break
                if n > values[i]:
                    values.insert(i, n)
                    break

        return values[0] if float('-inf') in values[:3] else values[2]