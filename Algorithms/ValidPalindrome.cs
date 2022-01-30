// https://leetcode.com/problems/valid-palindrome/
public class ValidPalindromeSolution
{
    public bool IsPalindrome(string s)
    {
        s = s.ToUpper();
        int start = 0;
        int end = s.Length - 1;

        while (start < end)
        {
            while (start < s.Length && !IsAlphaNumeric(s[start])) start++;
            while (end >= 0 && !IsAlphaNumeric(s[end])) end--;

            if (start > end) continue;
            if (s[start] != s[end]) return false;

            start++;
            end--;
        }

        return true;
    }

    public bool IsAlphaNumeric(char c)
    {
        return 'A' <= c && c <= 'Z'
            || '0' <= c && c <= '9';
    }
}

// https://leetcode.com/problems/valid-palindrome-ii/
public class ValidPalindromeIISolution
{
    public bool ValidPalindrome(string s)
    {
        return Helper(0, s.Length - 1);

        bool Helper(int left, int right, bool allowDeletion = true)
        {
            if (left > right) return true;

            if (s[left] == s[right]) return Helper(left + 1, right - 1, allowDeletion);
            if (allowDeletion)
            {
                return Helper(left, right - 1, false)
                    || Helper(left + 1, right, false);
            }

            return false;
        }
    }
}