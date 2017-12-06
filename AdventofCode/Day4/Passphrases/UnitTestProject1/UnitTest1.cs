using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Passphrases;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private CheckPassphrase _checkPassphrase { get; set; } 

        [TestInitialize]
        public void SetUp()
        {
            _checkPassphrase = new CheckPassphrase();
        }
        [TestMethod]
        public void TestMethod1()
        {
            List<string> passphrase = new List<string> {"aa", "bb", "cc", "dd", "ee"};
            bool isDistinct = _checkPassphrase.IsDistinct(passphrase);
            Assert.IsTrue(isDistinct);
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<string> passphrase = new List<string> { "aa", "bb", "cc", "dd", "aa" };
            bool isDistinct = _checkPassphrase.IsDistinct(passphrase);
            Assert.IsFalse(isDistinct);
        }

        [TestMethod]
        public void TestMethod3()
        {
            List<string> passphrase = new List<string> { "aa", "bb", "cc", "dd", "aaa" };
            bool isDistinct = _checkPassphrase.IsDistinct(passphrase);
            Assert.IsTrue(isDistinct);
        }

        [TestMethod]
        public void TestMethod1_Part2()
        {
            List<string> passphrase = new List<string> { "abcde", "fghij"};
            bool isDistinct = _checkPassphrase.NotAnagram(passphrase);
            Assert.IsTrue(isDistinct);
        }


        [TestMethod]
        public void TestMethod2_Part2()
        {
            List<string> passphrase = new List<string> { "abcde", "xyz", "ecdab" };
            bool isDistinct = _checkPassphrase.NotAnagram(passphrase);
            Assert.IsFalse(isDistinct);
        }

        [TestMethod]
        public void TestMethod3_Part2()
        {
            List<string> passphrase = new List<string> { "a", "ab", "abc", "abd", "abf", "abj" };
            bool isDistinct = _checkPassphrase.NotAnagram(passphrase);
            Assert.IsTrue(isDistinct);
        }

        [TestMethod]
        public void TestMethod4_Part2()
        {
            List<string> passphrase = new List<string> { "iiii", "oiii", "ooii", "oooi", "oooo" };
            bool isDistinct = _checkPassphrase.NotAnagram(passphrase);
            Assert.IsTrue(isDistinct);
        }

        [TestMethod]
        public void TestMethod5_Part2()
        {
            List<string> passphrase = new List<string> { "oiii", "ioii", "iioi", "iiio" };
            bool isDistinct = _checkPassphrase.NotAnagram(passphrase);
            Assert.IsFalse(isDistinct);
        }

    }
}
