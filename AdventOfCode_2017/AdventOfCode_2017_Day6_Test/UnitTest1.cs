using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AdventOfCode_2017_Day6_;

namespace AdventOfCode_2017_Day6_Test
{
    [TestClass]
    public class UnitTest1
    {
        private FileReader _fileReader;
        private MemoryHandler _memoryHandler;

        [TestInitialize]
        public void Setup()
        {
            _fileReader = new FileReader();
            _memoryHandler = new MemoryHandler();
        }
        [TestMethod]
        public void Day6_MemoryAllocation_part1()
        {
            List<int> memoryBank = new List<int>{0,2,7,0};
            int redistibutions = _memoryHandler.ReallocateMemory(memoryBank);
            Assert.AreEqual(5, redistibutions);
        }

        [TestMethod]
        public void Day6_MemoryAllocation_input_part1()
        {
            List<int> memoryBank = _fileReader.ReadFile(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventOfCode_2017\AdventOfCode_2017_Day6_Test\input.txt");
            int redistibutions = _memoryHandler.ReallocateMemory(memoryBank);
            Assert.AreEqual(12841, redistibutions);
        }

    }
}
