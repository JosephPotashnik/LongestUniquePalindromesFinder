using System;
using System.Collections.Generic;

namespace LongestUniquePalindromesFinderNS
{
    public class LongestUniquePalindromesFinder
    {
        private static void UpdateLongestPalindromes(LongestUniquePalindromes longestPalindromes, HashSet<string> nonUniquePalindromes, PalindromeData candidatePalindrome)
        {
            //if the candidate palindrome is strictly contained within another palindrome, it is not unique: continue
            if (longestPalindromes.IntervalContains(candidatePalindrome)) return;

            //if the candidate palindrome has already been recognized as not unique, continue.
            if (nonUniquePalindromes.Contains(candidatePalindrome.Palindrome)) return;

            if (!longestPalindromes.Contains(candidatePalindrome))
                longestPalindromes.Add(candidatePalindrome);
            else
            {
                //a palindrome of an equal length but different interval has been encountered before, it is not unique.
                //IMPORTANT: it also means that the palindrome that we have encountered is not unique as well.
                //remove it from the longest palindromes, and recognize it as non-unique.
                longestPalindromes.Remove(candidatePalindrome);
                nonUniquePalindromes.Add(candidatePalindrome.Palindrome);

            }
        }

        /// <summary>
        /// The main function to compute unique longest palindromes
        /// </summary>
        /// <param name="numOfPalindromes"> a positive integer </param>
        /// <param name="s"> the string to search palindromes in. Not null</param>
        /// <returns>a data structrue LongestUniquePalindromes containing at most numOfPalindromes unique longest palindromes </returns>
        public static LongestUniquePalindromes GetLongestUniquePalindromes(int numOfPalindromes, string s)
        {
            if (s == null) throw new ArgumentNullException("s");
            if (numOfPalindromes < 1) throw new ArgumentOutOfRangeException("numOfPalindromes");

            LongestUniquePalindromes longestPalindromes = new LongestUniquePalindromes();
            HashSet<string> nonUniquePalindromes = new HashSet<string>();

            bool foundAllPalindromes = false;

            //in decreasing string length
            for (int i = s.Length; i > 0; i--)
            {
                //there are (s.Length-i+1) possible partitions of length i. examine whether they are palindromes.
                int numberOfPartitions = s.Length - i + 1;
                for (int j = 0; j < numberOfPartitions; j++)
                {
                    string substringToCheck = s.Substring(j, i);
                    bool isPalindrome = PalindromeRecognizer.IsPalindrome(substringToCheck);

                    if (isPalindrome)
                    {
                        PalindromeData candidatePalindrome = new PalindromeData(j, i, substringToCheck);
                        UpdateLongestPalindromes(longestPalindromes, nonUniquePalindromes, candidatePalindrome);
                    }

                }

                //we have examined here all palindromes of length i.
                //check now if we have sufficient number of palindromes to return
                //IMPORTANT: we must traverse over all partitions of length i, in order to make
                //sure that we capture only the unique palindromes of that length.
                if (longestPalindromes.Count >= numOfPalindromes)
                {
                    foundAllPalindromes = true;
                    longestPalindromes.RemoveRange(numOfPalindromes, longestPalindromes.Count - numOfPalindromes);
                    break;
                }
            }

            //if we have not reached numOfPalindromes, add the empty string (a palindrome of length 0)
            //and return with whatever number of longest palindrome we have found.
            //i.e., Min ( longestPalindrome.Count, numOfPalindromes).
            if (!foundAllPalindromes)
            {

                PalindromeData candidatePalindrome = new PalindromeData(0, 0, string.Empty);
                longestPalindromes.Add(candidatePalindrome);
            }

            return longestPalindromes;
        }
    }
}
