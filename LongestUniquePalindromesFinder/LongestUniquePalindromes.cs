using System;
using System.Collections.Generic;
using System.Text;

namespace LongestUniquePalindromesFinderNS
{
    public class PalindromeData
    {
        public readonly int Index;
        public readonly int Length;
        public readonly string Palindrome;

        public PalindromeData(int index, int length, string palindrome)
        {
            Index = index;
            Length = length;
            Palindrome = palindrome;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            PalindromeData data = (PalindromeData)obj;
            return (Palindrome == data.Palindrome);
            //palindromes with different intervals but same string are equal.
        }

        public override int GetHashCode()
        {
            return Palindrome.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Text: {0}, Index: {1}, Length: {2}", Palindrome, Index, Length);
        }
    }
    public class LongestUniquePalindromes
    {
        private List<PalindromeData> longestPalindromes = new List<PalindromeData>();
        public int Count { get { return longestPalindromes.Count; } }


        public void Add(PalindromeData candidatePalindrome)
        {
            longestPalindromes.Add(candidatePalindrome);
        }

        public void Remove(PalindromeData candidatePalindrome)
        {
            longestPalindromes.Remove(candidatePalindrome);
        }
        public bool IntervalContains(PalindromeData candidatePalindrome)
        {
            foreach (var item in longestPalindromes)
            {
                if (item.Palindrome.Contains(candidatePalindrome.Palindrome) && item.Palindrome != candidatePalindrome.Palindrome)
                    return true;
            }

            return false;
        }

        public bool Contains(PalindromeData candidatePalindrome)
        {
            foreach (var item in longestPalindromes)
                if (candidatePalindrome.Palindrome == item.Palindrome) return true;

            return false;
        }

        internal void RemoveRange(int startIndex, int length)
        {
            longestPalindromes.RemoveRange(startIndex, length);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in longestPalindromes)
                builder.AppendLine(item.ToString());

            return builder.ToString();
        }
    }
}
