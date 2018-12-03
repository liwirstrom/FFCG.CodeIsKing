using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode_2018_Day1_Test
{
    [TestClass]
    public class FrequencyUnitTests
    {
        private FrequencyCalculator _frequencyCalculator;

        [TestInitialize]
        public void Setup()
        {
            _frequencyCalculator = new FrequencyCalculator();
        }


        [TestMethod]
        public void Should_Add_To_Frequency()
        {
            var input = new List<string>{"+1"};
            var currentFrequency = 0;
            currentFrequency = _frequencyCalculator.FindFrequency(currentFrequency,input);
            Assert.AreEqual(1, currentFrequency);

        }

        [TestMethod]
        public void Should_Subtract_To_Frequency()
        {
            var input = new List<string> { "-2" };
            var currentFrequency = 1;
            currentFrequency = _frequencyCalculator.FindFrequency(currentFrequency, input);
            Assert.AreEqual(-1, currentFrequency);
        }

        [TestMethod]
        public void UnitTest1_part1()
        {
            var input = new List<string> { "+1", "+1", "+1" };
            var currentFrequency = 0;
            currentFrequency = _frequencyCalculator.FindFrequency(currentFrequency, input);
            Assert.AreEqual(3, currentFrequency);
        }

        [TestMethod]
        public void UnitTest2_part1()
        {
            var input = new List<string> { "+1", "+1", "-2" };
            var currentFrequency = 0;
            currentFrequency = _frequencyCalculator.FindFrequency(currentFrequency, input);
            Assert.AreEqual(0, currentFrequency);
        }

        [TestMethod]
        public void UnitTest3_part1()
        {
            var input = new List<string> { "-1", "-2", "-3" };
            var currentFrequency = 0;
            currentFrequency = _frequencyCalculator.FindFrequency(currentFrequency, input);
            Assert.AreEqual(-6, currentFrequency);
        }

        [TestMethod]
        public void Answer_input_part1()
        {
            var input = File.ReadAllLines("../../Day1_input.txt").ToList();
            var currentFrequency = 0;
            currentFrequency = _frequencyCalculator.FindFrequency(currentFrequency, input);
            Assert.AreEqual(592, currentFrequency);
        }

        [TestMethod]
        public void Should_Return_first_duplicate()
        {
            var input = new List<string> { "+1", "-2","+3", "+1", "+1", "-2" };
            var currentFrequency = 0;
            currentFrequency = _frequencyCalculator.FindDuplicate(currentFrequency, input);
            Assert.AreEqual(2, currentFrequency);
        }

        [TestMethod]
        public void Unittest1_part2()
        {
            var input = new List<string> { "+1", "-1" };
            var currentFrequency = 0;
            currentFrequency = _frequencyCalculator.FindDuplicate(currentFrequency, input);
            Assert.AreEqual(0, currentFrequency);
        }


        [TestMethod]
        public void Unittest2_part2()
        {
            var input = new List<string> { "+3", "+3", "+4", "-2", "-4" };
            var currentFrequency = 0;
            currentFrequency = _frequencyCalculator.FindDuplicate(currentFrequency, input);
            Assert.AreEqual(10, currentFrequency);
        }

        [TestMethod]
        public void Unittest3_part2()
        {
            var input = new List<string> { "-6", "+3", "+8", "+5", "-6" };
            var currentFrequency = 0;
            currentFrequency = _frequencyCalculator.FindDuplicate(currentFrequency, input);
            Assert.AreEqual(5, currentFrequency);
        }

        [TestMethod]
        public void Unittest4_part2()
        {
            var input = new List<string> { "+7", "+7", "-2", "-7", "-4" };
            var currentFrequency = 0;
            currentFrequency = _frequencyCalculator.FindDuplicate(currentFrequency, input);
            Assert.AreEqual(14, currentFrequency);
        }

        [TestMethod]
        public void Answer_input_part2()
        {
            var input = File.ReadAllLines("../../Day1_input.txt").ToList();
            var currentFrequency = 0;
            currentFrequency = _frequencyCalculator.FindDuplicate(currentFrequency, input);
            Assert.AreEqual(241, currentFrequency);
        }
    }
}
