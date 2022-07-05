class Solution:
    def licenseKeyFormatting(self, s: str, k: int) -> str:
        s = s.replace('-', '').upper()
        i = len(s) % k
        parts = [s[0:i]] if i != 0 else []

        while i + k <= len(s):
            parts.append(s[i:i + k])
            i += k

        return '-'.join(parts)

        # Simpler, pythonic solution. Works because taking [i:i + k] where k is larger then the length of the string will just return the rest of the string and not throw an out of bounds.

        # s = s.replace('-', '').upper()[::-1]
        # return '-'.join(s[i:i + k] for i in range(0, len(s), k))[::-1]