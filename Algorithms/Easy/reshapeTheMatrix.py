# https://leetcode.com/problems/reshape-the-matrix/
from typing import List

class Solution:
    def matrixReshape(self, mat: List[List[int]], r: int, c: int) -> List[List[int]]:
        if mat and len(mat) * len(mat[0]) != r * c: return mat

        result = []
        current = []
        for i, n in enumerate([mat[i][j] for i in range(len(mat)) for j in range(len(mat[0]))]):
            current.append(n)
            if len(current) == c:
                result.append(current)
                current = []

        return result
