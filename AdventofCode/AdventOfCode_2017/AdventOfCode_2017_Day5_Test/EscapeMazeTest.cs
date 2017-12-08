using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AdventOfCode_2017_Day5;

namespace AdventOfCode_2017_Day5_Test
{
    [TestClass]
    public class EscapeMazeTest
    {
        private FileReader _fileReader { get; set; }
        private EscapeMaze _escapeMaze { get; set; }

        [TestInitialize]
        public void Setup()
        {
            _fileReader = new FileReader();
            _escapeMaze = new EscapeMaze();
        }
        [TestMethod]
        public void Day5_TestMethod1_part1()
        {
            List<int> instructions = new List<int> { 0, 3, 0, 1, -3 };
            int steps = _escapeMaze.Jump(instructions);
            Assert.AreEqual(5, steps);
        }

        [TestMethod]
        public void Day5_TestMethod2_part1()
        {
            List<int> instructions = _fileReader.ReadFile(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\AdventOfCode_2017\AdventOfCode_2017_Day5_Test\input.txt");
            int steps = _escapeMaze.Jump(instructions);
            Assert.AreEqual(315613, steps);
        }

        [TestMethod]
        public void Day5_TestMethod1_part2()
        {
            List<int> instructions = new List<int> { 0, 3, 0, 1, -3 };
            int steps = _escapeMaze.JumpAndDecreaseAbove2(instructions);
            Assert.AreEqual(10, steps);
        }

        [TestMethod]
        public void Day5_TestMethod2_part2()
        {
            List<int> instructions = _fileReader.ReadFile(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\AdventOfCode_2017\AdventOfCode_2017_Day5_Test\input.txt");
            int steps = _escapeMaze.JumpAndDecreaseAbove2(instructions);
            Assert.AreEqual(22570529, steps);
        }
    }
}
