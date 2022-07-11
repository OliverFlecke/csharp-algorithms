# https://leetcode.com/problems/relative-ranks/
from typing import List

class Solution:
    def findRelativeRanks(self, score: List[int]) -> List[str]:
        def toPlace(i: int) -> str:
            if i == 0: return 'Gold Medal'
            if i == 1: return 'Silver Medal'
            if i == 2: return 'Bronze Medal'
            return str(i + 1)

        m = {}

        for i, s in enumerate(sorted(score)[::-1]):
            m[s] = toPlace(i)

        return [m[s] for s in score]
