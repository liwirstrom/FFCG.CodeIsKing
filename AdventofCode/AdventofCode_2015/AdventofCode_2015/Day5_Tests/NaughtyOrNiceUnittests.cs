using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day5_Tests
{
    [TestClass]
    public class NaughtyOrNiceUnittests
    {
        private SantasList _santasList;

        [TestInitialize]
        public void Setup()
        {
            _santasList = new SantasList();
        }

        [TestMethod]
        public void Unittest1_Should_be_nice_part1()
        {
            var isNice = _santasList.IsNice("ugknbfddgicrmopn");
            Assert.IsTrue(isNice);
        }

        [TestMethod]
        public void Unittest2_Should_be_naughty_part1()
        {
            var isNice = _santasList.IsNice("jchzalrnumimnmhp");
            Assert.IsFalse(isNice);
        }

        [TestMethod]
        public void Unittest3_Should_be_naughty_part1()
        {
            var isNice = _santasList.IsNice("haegwjzuvuyypxyu");
            Assert.IsFalse(isNice);
        }

        [TestMethod]
        public void Unittest4_Should_be_naughty_part1()
        {
            var isNice = _santasList.IsNice("dvszwmarrgswjxmb");
            Assert.IsFalse(isNice);
        }

        [TestMethod]
        public void Answer_Input_part1()
        {
            var countNice = 0;
            foreach (var line in File.ReadLines("../../../Day5_input.txt"))
            {  
                if (_santasList.IsNice(line) == true)
                {
                    countNice++;
                }
            }
            
            Assert.AreEqual(255, countNice);
        }

        [TestMethod]
        public void Unittest1_Should_be_nice_part2()
        {
            var isNice = _santasList.IsNicer("qjhvhtzxzqqjkmpb");
            Assert.IsTrue(isNice);
        }

        [TestMethod]
        public void Unittest2_Should_be_nice_part2()
        {
            var isNice = _santasList.IsNicer("xxyxx");
            Assert.IsTrue(isNice);
        }

        [TestMethod]
        public void Unittest3_Should_be_naughty_part2()
        {
            var isNice = _santasList.IsNicer("uurcxstgmygtbstg");
            Assert.IsFalse(isNice);
        }

        [TestMethod]
        public void Unittest4_Should_be_naughty_part2()
        {
            var isNice = _santasList.IsNicer("ieodomkazucvgmuy");
            Assert.IsFalse(isNice);
        }

        [TestMethod]
        public void Answer_Input_part2()
        {
            var countNice = 0;
            foreach (var line in File.ReadLines("../../../Day5_input.txt"))
            {
                if (_santasList.IsNicer(line) == true)
                {
                    countNice++;
                }
            }

            Assert.AreEqual(55, countNice);
        }

    }
}
