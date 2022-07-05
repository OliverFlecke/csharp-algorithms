class Solution:
    def islandPerimeter(self, grid: List[List[int]]) -> int:
        n = len(grid)
        m = len(grid[0])
        perimeter = 0
        for x in range(n):
            for y in range(m):
                if grid[x][y] == 0: continue

                neighbours = [grid[x + dx][y + dy]
                              if x + dx >= 0 and x + dx < n and y + dy >= 0 and y + dy < m
                              else 0
                              for dx, dy in [(0, 1), (1, 0), (-1, 0), (0, -1)]]
                perimeter += 4 - sum(neighbours)

        return perimeter
