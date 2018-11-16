using System;
using Common;
using Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Day1_tests
{
    [TestClass]
    public class WhichFloorUnitTests
    {
        private Day1_FloorCalculator _day1FloorCalculator;
        private FileReader _fileReader;

        [TestInitialize]
        public void Setup() {
            _day1FloorCalculator = new Day1_FloorCalculator();
            _fileReader = new FileReader();
        }

        [TestMethod]
        public void Should_be_on_ground_floor_part1()
        {
            var floor = _day1FloorCalculator.GetFloor("(())");
            var floor1 = _day1FloorCalculator.GetFloor("()()");

            Assert.AreEqual(0,floor);
            Assert.AreEqual(0,floor1);
        }

        [TestMethod]
        public void Should_be_on_third_floor_part1()
        {
            var floor = _day1FloorCalculator.GetFloor("(((");
            var floor2 = _day1FloorCalculator.GetFloor("(()(()(");

            Assert.AreEqual(3, floor);
            Assert.AreEqual(3, floor2);
        }

        [TestMethod]
        public void Should_be_on_first_basement_part1()
        {
            var floor = _day1FloorCalculator.GetFloor("())");
            var floor2 = _day1FloorCalculator.GetFloor("))(");

            Assert.AreEqual(-1, floor);
            Assert.AreEqual(-1, floor2);
        }

        [TestMethod]
        public void Should_be_on_third_basement_part1()
        {
            var floor = _day1FloorCalculator.GetFloor(")))");
            var floor2 = _day1FloorCalculator.GetFloor(")())())");

            Assert.AreEqual(-3, floor);
            Assert.AreEqual(-3, floor2);
        }

        [TestMethod]
        public void Answer_input_part1()
        {
            var input = _fileReader.ReadFile("../../../input.txt");
            var floor = _day1FloorCalculator.GetFloor(input[0][0]);

            Assert.AreEqual(280, floor);
        }


        [TestMethod]
        public void Should_never_reach_basement_part2()
        {
            var index = _day1FloorCalculator.GetFirstBasementCharacter("(((");

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void Should_reach_basement_part2()
        {
            var index = _day1FloorCalculator.GetFirstBasementCharacter("(()))");

            Assert.AreEqual(5, index);
        }

        [TestMethod]
        public void Answer_input_part2()
        {
            var input = _fileReader.ReadFile("../../../input.txt");
            var index = _day1FloorCalculator.GetFirstBasementCharacter(input[0][0]);

            Assert.AreEqual(1797, index);
        }

    }
}
