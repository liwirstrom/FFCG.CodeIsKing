using System;
using SpiralGridModell;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManhattanDistance
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Should_find_Position1_part1()
        {
            SpiralGridModel gridModel = new SpiralGridModel();
            NumberModel number = gridModel.FindPosition(23);
            Assert.AreEqual(0, number.X_position);
            Assert.AreEqual(-2, number.Y_position);
            int steps = gridModel.GetDistance(number);
            Assert.AreEqual(2,steps);
        }

        [TestMethod]
        public void Should_find_Position2_part1()
        {
            SpiralGridModel gridModel = new SpiralGridModel();
            NumberModel number = gridModel.FindPosition(1024);
            int steps = gridModel.GetDistance(number);
            Assert.AreEqual(31, steps);
        }

        [TestMethod]
        public void Should_find_Position3_part1()
        {
            SpiralGridModel gridModel = new SpiralGridModel();
            NumberModel number = gridModel.FindPosition(12);
            Assert.AreEqual(2, number.X_position);
            Assert.AreEqual(1, number.Y_position);
            int steps = gridModel.GetDistance(number);
            Assert.AreEqual(3, steps);
        }

        [TestMethod]
        public void Should_find_Position4_part1()
        {
            SpiralGridModel gridModel = new SpiralGridModel();
            NumberModel number = gridModel.FindPosition(1);
            Assert.AreEqual(0, number.X_position);
            Assert.AreEqual(0, number.Y_position);
            int steps = gridModel.GetDistance(number);
            Assert.AreEqual(0, steps);
        }
    }
}
