using System.Collections.Generic;
using Common;
using Day2_WrappingPaperProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day2_Tests
{
    [TestClass]
    public class Day2_PresentCalculator_Unit_tests
    {
        private FileReader _fileReader;
        private PresentCalculator _presentCalculator;

        [TestInitialize]
        public void Setup()
        {
            _fileReader = new FileReader();
            _presentCalculator = new PresentCalculator();
        }

        [TestMethod]
        public void Should_Calculate_Correct_Amount_part1()
        {
            var inputsize = new List<string> { "2","3","4"};
            var paperAmount = _presentCalculator.CalculateSquareBoxAmount(inputsize);

            Assert.AreEqual(58, paperAmount);
        }

        [TestMethod]
        public void Should_Calculate_Correct_Amount2_part1()
        {
            var inputsize = new List<string> { "1", "1", "10" };
            var paperAmount = _presentCalculator.CalculateSquareBoxAmount(inputsize);

            Assert.AreEqual(43, paperAmount);
        }


        [TestMethod]
        public void Answer_input_part1()
        {
            var inputs = _fileReader.ReadFileWithSeparator("../../../Day2_Input.txt",'x');

            var paperAmount = 0;

            foreach (var input in inputs)
            {
                paperAmount += _presentCalculator.CalculateSquareBoxAmount(input);
            }


            Assert.AreEqual(1598415, paperAmount);
        }

        [TestMethod]
        public void Should_Calculate_Correct_Amount1_part2()
        {
            var inputsize = new List<string> { "2", "3", "4"};
            var ribbonLength = _presentCalculator.CalculateRibbonAmount(inputsize);

            Assert.AreEqual(34, ribbonLength);
        }

        [TestMethod]
        public void Should_Calculate_Correct_Amount2_part2()
        {
            var inputsize = new List<string> { "1", "1", "10" };
            var ribbonLength = _presentCalculator.CalculateRibbonAmount(inputsize);

            Assert.AreEqual(14, ribbonLength);
        }

        [TestMethod]
        public void Answer_input_part2()
        {
            var inputs = _fileReader.ReadFileWithSeparator("../../../Day2_Input.txt", 'x');

            var ribbonLength = 0;
           
            foreach (var input in inputs)
            {
               ribbonLength+= _presentCalculator.CalculateRibbonAmount(input);
            }

            Assert.AreEqual(3812909, ribbonLength);
        }

    }
}
