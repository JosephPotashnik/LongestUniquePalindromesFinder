using LongestUniquePalindromesFinderNS;
using System;
using Xunit;

namespace LongestUniquePalindromesTests
{
    public class LongestUniquePalindromeTests
    {
        [Fact]
        public void TestLongestPalindromeIntervalContainsTrue()
        {
            PalindromeData p = new PalindromeData(0, 3, "abba");
            LongestUniquePalindromes l = new LongestUniquePalindromes();
            l.Add(p);
            PalindromeData candidate = new PalindromeData(1, 2, "bb");
            bool expected = l.IntervalContains(candidate);
            Assert.True(expected);

        }

        [Fact]
        public void TestLongestPalindromeIntervalContainsFalse()
        {
            PalindromeData p = new PalindromeData(0, 3, "abcbacc");
            LongestUniquePalindromes l = new LongestUniquePalindromes();
            l.Add(p);
            //note: candidate is not a palindrome, but we are interested only in the interval containment
            //property, for which being palindrome is irrelevant.
            PalindromeData candidate = new PalindromeData(4, 3, "acc");
            bool expected = l.IntervalContains(candidate);
            Assert.False(expected);

        }

        [Fact]
        public void TestLongestPalindromeUniqueFalse()
        {
            PalindromeData p1 = new PalindromeData(0, 2, "aa");
            PalindromeData p2 = new PalindromeData(2, 2, "bb");

            LongestUniquePalindromes l = new LongestUniquePalindromes();
            l.Add(p1);
            l.Add(p2);

            PalindromeData candidate = new PalindromeData(1, 2, "bb");
            bool expected = l.Contains(candidate);
            Assert.True(expected);

        }

        [Fact]
        public void TestLongestPalindromeUniqueTrue()
        {
            PalindromeData p1 = new PalindromeData(0, 2, "aa");
            PalindromeData p2 = new PalindromeData(2, 2, "bb");

            LongestUniquePalindromes l = new LongestUniquePalindromes();
            l.Add(p1);
            l.Add(p2);

            PalindromeData candidate = new PalindromeData(1, 2, "cc");
            bool expected = l.Contains(candidate);
            Assert.False(expected);

        }
    }
    
}
