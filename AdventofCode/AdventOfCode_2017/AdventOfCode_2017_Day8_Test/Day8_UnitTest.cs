using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode_2017_Day8;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2017_Day8_Test
{
    [TestClass]
    public class Day8_UnitTest
    {
        private RegisterHandler _registerHandler;
        [TestInitialize]
        public void Setup()
        {
            _registerHandler = new RegisterHandler();
        }
        [TestMethod]
        public void Day8_TestMethod1_part1()
        {
            List<Register> registry = _registerHandler.PerformRegisterInstructions(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\AdventOfCode_2017\AdventOfCode_2017_Day8_Test\testInput.txt");
            int highestValue = _registerHandler.GetHighestRegisterValue(registry);
            Assert.AreEqual(1, highestValue);
        }

        [TestMethod]
        public void Day8_TestMethod_input_part1()
        {
            List<Register> registry = _registerHandler.PerformRegisterInstructions(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\AdventOfCode_2017\AdventOfCode_2017_Day8_Test\input.txt");
            int highestValue = _registerHandler.GetHighestRegisterValue(registry);
            Assert.AreEqual(3745, highestValue);
        }

        [TestMethod]
        public void Day8_TestMethod1_part2()
        {
            List<Register> registry = _registerHandler.PerformRegisterInstructions(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\AdventOfCode_2017\AdventOfCode_2017_Day8_Test\testInput.txt");
            int highestHeldValue = registry.Where(r => r.Name == "HighestHeldValue").First().Value;
            Assert.AreEqual(10, highestHeldValue);
        }

        [TestMethod]
        public void Day8_TestMethod_input_part2()
        {
            List<Register> registry = _registerHandler.PerformRegisterInstructions(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\AdventOfCode_2017\AdventOfCode_2017_Day8_Test\input.txt");
            int highestHeldValue = registry.Where(r => r.Name == "HighestHeldValue").First().Value;
            Assert.AreEqual(4644, highestHeldValue);
        }
    }
}
