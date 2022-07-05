class Solution:
    def constructRectangle(self, area: int) -> List[int]:
        for n in range(2, math.floor(math.sqrt(area) + 1))[::-1]:
            if area % n == 0:
                return [area // n, n]

        return [area, 1]