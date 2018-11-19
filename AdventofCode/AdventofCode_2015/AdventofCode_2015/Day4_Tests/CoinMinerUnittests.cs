using Day4;
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
            var number = _coinMiner.Mine(input,5);

            Assert.AreEqual(609043, number);
        }

        [TestMethod]
        public void Unittest2_part1()
        {
            var input = "pqrstuv";
            var number = _coinMiner.Mine(input, 5);

            Assert.AreEqual(1048970, number);
        }

        [TestMethod]
        public void Answer_input_part1()
        {
            var input = "ckczppom";
            var number = _coinMiner.Mine(input, 5);

            Assert.AreEqual(117946, number);
        }

        [TestMethod]
        public void Answer_input_part2()
        {
            var input = "ckczppom";
            var number = _coinMiner.Mine(input, 6);

            Assert.AreEqual(3938038, number);
        }
    }
}
