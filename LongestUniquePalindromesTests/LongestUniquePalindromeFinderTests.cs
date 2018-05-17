using LongestUniquePalindromesFinderNS;
using System;
using Xunit;

namespace LongestUniquePalindromesTests
{
    public class LongestUniquePalindromeFinderTests
    {
        private const int numberOfPalindromes = 3;

        [Fact]
        public void TestNullStringPalindromFinderException()
        {
            string s = null;
            Exception ex = Assert.Throws<ArgumentNullException>(() => LongestUniquePalindromesFinder.GetLongestUniquePalindromes(numberOfPalindromes, s));
        }

        [Fact]
        public void TestNumberOfPalindromesOutOfRangeException()
        {
            string s = "abc";
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => LongestUniquePalindromesFinder.GetLongestUniquePalindromes(-1, s));
        }


        [Fact]
        public void TestPalindromeFromSpecification()
        {
            string s = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            var res = LongestUniquePalindromesFinder.GetLongestUniquePalindromes(numberOfPalindromes, s);
            LongestUniquePalindromes expected = new LongestUniquePalindromes();
            expected.Add(new PalindromeData(23, 10, "hijkllkjih"));
            expected.Add(new PalindromeData(13, 8, "defggfed"));
            expected.Add(new PalindromeData(5, 6, "abccba"));

            Assert.Equal(expected.ToString(), res.ToString());

        }

        [Fact]
        public void TestNonUniquePalindromes()
        {
            string s = "aaa";
            var res = LongestUniquePalindromesFinder.GetLongestUniquePalindromes(numberOfPalindromes, s);
            LongestUniquePalindromes expected = new LongestUniquePalindromes();
            expected.Add(new PalindromeData(0, 3, "aaa"));
            expected.Add(new PalindromeData(0, 0, string.Empty));
            Assert.Equal(expected.ToString(), res.ToString());

        }

        [Fact]
        public void TestOnlyCharactersPalindromeContainingExactlyKPalindromes()
        {
            string s = "abc";
            var res = LongestUniquePalindromesFinder.GetLongestUniquePalindromes(numberOfPalindromes, s);
            LongestUniquePalindromes expected = new LongestUniquePalindromes();
            expected.Add(new PalindromeData(0, 1, "a"));
            expected.Add(new PalindromeData(1, 1, "b"));
            expected.Add(new PalindromeData(2, 1, "c"));

            Assert.Equal(expected.ToString(), res.ToString());
        }

        [Fact]
        public void TestOnlyCharactersPalindromeContainingLessThanKPalindromes()
        {
            string s = "ab";
            var res = LongestUniquePalindromesFinder.GetLongestUniquePalindromes(numberOfPalindromes, s);
            LongestUniquePalindromes expected = new LongestUniquePalindromes();
            expected.Add(new PalindromeData(0, 1, "a"));
            expected.Add(new PalindromeData(1, 1, "b"));
            expected.Add(new PalindromeData(0, 0, string.Empty));

            Assert.Equal(expected.ToString(), res.ToString());

        }


        [Fact]
        public void TestOnlyCharactersPalindromeContainingMoreThanKPalindromes()
        {
            string s = "abcd";
            var res = LongestUniquePalindromesFinder.GetLongestUniquePalindromes(numberOfPalindromes, s);
            LongestUniquePalindromes expected1 = new LongestUniquePalindromes();
            expected1.Add(new PalindromeData(0, 1, "a"));
            expected1.Add(new PalindromeData(1, 1, "b"));
            expected1.Add(new PalindromeData(2, 1, "c"));

            Assert.Equal(expected1.ToString(), res.ToString());

            //NOTE: this is not the only solution ( "a", "b", "d") or ("b", "c", "d") are also valid
            //if the implmentation changes, this test may fail.
            //TO DO: add to the test all sets of longest unique palindromes.
        }

        [Fact]
        public void TestPalindromeContainingExactlyKPalindromes()
        {
            string s = "aaabbbbcc";
            var res = LongestUniquePalindromesFinder.GetLongestUniquePalindromes(numberOfPalindromes, s);
            LongestUniquePalindromes expected = new LongestUniquePalindromes();
            expected.Add(new PalindromeData(3, 4, "bbbb"));
            expected.Add(new PalindromeData(0, 3, "aaa"));
            expected.Add(new PalindromeData(7, 2, "cc"));

            Assert.Equal(expected.ToString(), res.ToString());

        }

        [Fact]
        public void TestPalindromeContainingLessThanKPalindromes()
        {
            string s = "aabbb";
            var res = LongestUniquePalindromesFinder.GetLongestUniquePalindromes(numberOfPalindromes, s);
            LongestUniquePalindromes expected = new LongestUniquePalindromes();
            expected.Add(new PalindromeData(2, 3, "bbb"));
            expected.Add(new PalindromeData(0, 2, "aa"));
            expected.Add(new PalindromeData(0, 0, string.Empty));

            Assert.Equal(expected.ToString(), res.ToString());
        }

        [Fact]
        public void TestPalindromeContainingMoreThanKPalindromes()
        {
            string s = "aaaabbbbbbcccddd";
            var res = LongestUniquePalindromesFinder.GetLongestUniquePalindromes(numberOfPalindromes, s);

            LongestUniquePalindromes expected1 = new LongestUniquePalindromes();
            expected1.Add(new PalindromeData(4, 6, "bbbbbb"));
            expected1.Add(new PalindromeData(0, 4, "aaaa"));
            expected1.Add(new PalindromeData(10, 3, "ccc"));

            Assert.Equal(expected1.ToString(), res.ToString());

            //NOTE: this is not the only solution.
            //if the implmentation changes, this test may fail.
            //TO DO: add to the test all sets of longest unique palindromes.

        }
    }
}