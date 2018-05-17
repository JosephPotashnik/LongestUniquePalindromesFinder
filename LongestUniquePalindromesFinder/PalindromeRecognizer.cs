using System;

namespace LongestUniquePalindromesFinderNS
{
    public class PalindromeRecognizer
    {
        public static bool IsPalindrome(string s)
        {
            if (s == null) throw new ArgumentNullException("s");

            int length = s.Length;

            //assumption: String.Empty is a palindrome of length 0.
            //by definition, a string of length 1 is a palindrome.
            if (length == 1 || length == 0) return true;

            for (int i = 0; i < (length / 2); i++)
                if (s[i] != s[length - (i + 1)]) return false;

            //note: if the string is odd-length, we do not have to check the middle character since
            //any single character is a palindrome.
            return true;
        }
    }
}