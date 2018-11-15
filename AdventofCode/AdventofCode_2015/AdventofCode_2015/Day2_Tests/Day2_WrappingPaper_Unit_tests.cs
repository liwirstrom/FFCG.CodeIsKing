using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day2_Tests
{
    [TestClass]
    public class Day2_WrappingPaper_Unit_tests
    {
        private FileReader _fileReader;
        private WrappingpaperCalculator _wrappingpaperCalculator;

        [TestInitialize]
        public void Setup()
        {
            _fileReader = new FileReader();
            _wrappingpaperCalculator = new WrappingpaperCalculator();
        }

        [TestMethod]
        public void Should_Calculate_Correct_Amount_part1()
        {
            var inputsize = new List<string> { "2","3","4"};
            var paperAmount = _wrappingpaperCalculator.CalculateSquareBoxAmount(inputsize);

            Assert.AreEqual(58, paperAmount);
        }

        [TestMethod]
        public void Should_Calculate_Correct_Amount2_part1()
        {
            var inputsize = new List<string> { "1", "1", "10" };
            var paperAmount = _wrappingpaperCalculator.CalculateSquareBoxAmount(inputsize);

            Assert.AreEqual(43, paperAmount);
        }


        [TestMethod]
        public void Answer_input_part1()
        {
            var inputs = _fileReader.ReadFileWithSeparator(
                @"C:\Users\se-liwirs-01\Documents\FFCG.CodeIsKing\AdventofCode\AdventofCode_2015\AdventofCode_2015\Day2_Input.txt",
                'x');

            var paperAmount = 0;

            foreach (var input in inputs)
            {
                paperAmount += _wrappingpaperCalculator.CalculateSquareBoxAmount(input);
            }


            Assert.AreEqual(0, paperAmount);
        }

    }

    public class WrappingpaperCalculator
    {
        public int CalculateSquareBoxAmount(List<string> inputsize)
        {
            var amount = 0;
            var dimensions = inputsize.Select(int.Parse).ToList();

            amount += 2 * dimensions[0] * dimensions[1];
            amount += 2 * dimensions[0] * dimensions[2];
            amount += 2 * dimensions[1] * dimensions[2];

            amount += GetSmallestSide(dimensions);

            return amount;
        }

        private int GetSmallestSide(List<int> dimensions)
        {
            if (dimensions.Count >= 3)
            {
                var sideAreas = new List<int>();
                sideAreas.Add(dimensions[0] * dimensions[1]);
                sideAreas.Add(dimensions[0] * dimensions[2]);

                sideAreas.Sort();

                return sideAreas[0];
            }

            return 0;

        }
    }
}
