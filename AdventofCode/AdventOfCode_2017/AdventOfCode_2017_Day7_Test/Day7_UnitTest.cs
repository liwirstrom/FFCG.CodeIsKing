using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AdventOfCode_2017_Day7;
using System.Linq;

namespace AdventOfCode_2017_Day7_Test
{
    [TestClass]
    public class Day7_UnitTest
    {
        private FileReader _fileReader;

        [TestInitialize]
        public void Setup()
        {
            _fileReader = new FileReader();
        }

        [TestMethod]
        public void Day7_TestMethod1_Part1()
        {
            List<ProgramModel> programList = _fileReader.ReadFile(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\AdventOfCode_2017\AdventOfCode_2017_Day7_Test\testInput.txt");
            ProgramHandler programHandler = new ProgramHandler(programList);
            string rootProgram = programHandler.GetBottom(programList);
            Assert.AreEqual("tknk", rootProgram);
        }
        [TestMethod]
        public void Day7_TestMethod2_input_Part1()
        {
            List<ProgramModel> programList = _fileReader.ReadFile(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\AdventOfCode_2017\AdventOfCode_2017_Day7_Test\input.txt");
            ProgramHandler programHandler = new ProgramHandler(programList);
            string rootProgram = programHandler.GetBottom(programList);
            Assert.AreEqual("uownj", rootProgram);
        }

        [TestMethod]
        public void Day7_TestMethod1_Part2()
        {
            List<ProgramModel> programList = _fileReader.ReadFile(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\AdventOfCode_2017\AdventOfCode_2017_Day7_Test\testInput.txt");
            ProgramHandler programHandler = new ProgramHandler(programList);
            string rootProgramName = programHandler.GetBottom(programList);
            int originalRootWeight = programList.FirstOrDefault(p => p.Name == rootProgramName).Weight;
            int rootProgramHolding = programHandler.GetHoldingWeight(rootProgramName);
            //int rootProgramWeight = programList.FirstOrDefault(p => p.Name == rootProgramName).Weight - originalRootWeight;
            //Assert.AreEqual(737, rootProgramWeight);
            Assert.AreEqual(737, rootProgramHolding);

            //int adjustedWeight = _programHandler.GetAdjustedWeight();
        }

        [TestMethod]
        public void Day7_TestMethod2_input_Part2()
        {
            List<ProgramModel> programList = _fileReader.ReadFile(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\AdventOfCode_2017\AdventOfCode_2017_Day7_Test\input.txt");
            ProgramHandler programHandler = new ProgramHandler(programList);
            string bottomProgram = programHandler.GetBottom(programList);
            Assert.AreEqual("uownj", bottomProgram);
        }
    }
}
