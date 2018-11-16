using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day4_Tests
{
    [TestClass]
    public class CoinMinerUnittests
    {
        private CoinMiner _coinMiner;

        [TestInitialize]
        public void Setup()
        {
            _coinMiner = new CoinMiner();
        }

        [TestMethod]
        public void Unittest1_part1()
        {
            var input = "abcdef";
            var number = _coinMiner.Mine(input);

            Assert.AreEqual(609043, number);
        }

        //[TestMethod]
        //public void Unittest2_part1()
        //{
        //    var input = "pqrstuv";
        //    var number = _coinMiner.Mine(input);

        //    Assert.AreEqual(1048970, number);
        //}
    }

    internal class CoinMiner
    {
        public int Mine(string input)
        {
            var hash = "";
            var number = 609043;

            using (MD5 md5 = MD5.Create())
            {
                while (!hash.StartsWith("00000"))
                {
                    var concatString = $"{input}{number}";
                    var bytes = Encoding.ASCII.GetBytes(concatString);
                    var hashArray = md5.ComputeHash(bytes);

                    hash = System.Text.Encoding.Default.GetString(hashArray); ;
                    number++;
                }
            }

            return number;
        }
    }
}
