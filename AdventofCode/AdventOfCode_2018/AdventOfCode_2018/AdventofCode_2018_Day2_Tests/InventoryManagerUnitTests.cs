using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventofCode_2018_Day2_Tests
{
    [TestClass]
    public partial class InventoryManagerUnitTests
    {
        private InventoryManager _inventoryManager;

        [TestInitialize]
        public void Setup()
        {
            _inventoryManager = new InventoryManager();
        }

        [TestMethod]
        public void Checksum_Should_Be_1()
        {
            var input = new List<string> {"bababc"};
            var checkSum = _inventoryManager.GetCheckSum(input);
            Assert.AreEqual(1, checkSum);
        }

        [TestMethod]
        public void Checksum_Should_Be_2()
        {
            var input = new List<string> {"bababc", "abbcde"};
            var checkSum = _inventoryManager.GetCheckSum(input);
            Assert.AreEqual(2, checkSum);
        }

        [TestMethod]
        public void Checksum_Should_Be_3()
        {
            var input = new List<string> {"bababc", "abbcde", "aabcdd"};
            var checkSum = _inventoryManager.GetCheckSum(input);
            Assert.AreEqual(3, checkSum);

        }

        [TestMethod]
        public void Checksum_Should_Be_12()
        {
            var input = new List<string> { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" };
            var checkSum = _inventoryManager.GetCheckSum(input);
            Assert.AreEqual(12, checkSum);
        }

        [TestMethod]
        public void Answer_input_part1()
        {
            var input = File.ReadAllLines("../../Day2_input.txt").ToList();
            var checkSum = _inventoryManager.GetCheckSum(input);
            Assert.AreEqual(5704, checkSum);
        }

        [TestMethod]
        public void Should_Return_Match()
        {
            var input = new List<string> { "fghij", "fguij" };
            string commonChars = _inventoryManager.GetMostSimilar(input);
            Assert.AreEqual("fgij", commonChars);
        }

        [TestMethod]
        public void UnitTest1_part2()
        {
            var input = new List<string> { "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz" };
            string commonChars = _inventoryManager.GetMostSimilar(input);
            Assert.AreEqual("fgij", commonChars);
        }

        [TestMethod]
        public void Answer_input_part2()
        {
            var input = File.ReadAllLines("../../Day2_input.txt").ToList();
            var checkSum = _inventoryManager.GetMostSimilar(input);
            Assert.AreEqual("umdryabviapkozistwcnihjqx", checkSum);
        }
    }
}
