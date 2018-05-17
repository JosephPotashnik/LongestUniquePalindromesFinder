using LongestUniquePalindromesFinderNS;
using System;
using Xunit;

namespace LongestUniquePalindromesTests
{
    public class PalindromeRecognizerTests
    {
        [Fact]
        public void TestSingleCharacterPalindrome()
        {
            string s = "a";
            bool ret = PalindromeRecognizer.IsPalindrome(s);
            Assert.True(ret);

        }

        [Fact]
        public void TestEmptyStringPalindrome()
        {
            string s = string.Empty;
            bool ret = PalindromeRecognizer.IsPalindrome(s);
            Assert.True(ret);

        }

        [Fact]
        public void TestNullStringPalindromException()
        {
            string s = null;
            Exception ex = Assert.Throws<ArgumentNullException>(() => PalindromeRecognizer.IsPalindrome(s));
        }

        [Fact]
        public void TestEvenLengthPalindrome()
        {
            string s = "abba";
            bool ret = PalindromeRecognizer.IsPalindrome(s);
            Assert.True(ret);

        }

        [Fact]
        public void TestOddLengthPalindrome()
        {
            string s = "abxba";
            bool ret = PalindromeRecognizer.IsPalindrome(s);
            Assert.True(ret);

        }

        [Fact]
        public void TestNonPalindrome()
        {
            string s = "abxvba";
            bool ret = PalindromeRecognizer.IsPalindrome(s);
            Assert.False(ret);

        }
    }
}
