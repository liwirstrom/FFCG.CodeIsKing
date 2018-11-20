using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day6_Tests
{
    [TestClass]
    public class DecorationsUnittests
    {

        private HouseDecorator _houseDecorator;

        [TestInitialize]
        public void Setup()
        {
            _houseDecorator = new HouseDecorator(1000);
        }

        [TestMethod]
        public void All_lights_are_on_part1()
        {
            var lightsLit = _houseDecorator.TurnOnChristmasLights(new List<string> { "turn on 0,0 through 999,999" });
            Assert.AreEqual(1000000, lightsLit);
        }

        [TestMethod]
        public void Nine_lights_are_on_part1()
        {
            var lightsLit = _houseDecorator.TurnOnChristmasLights(new List<string> { "turn on 0,0 through 2,2", "turn off 0,0 through 0,0" });
            Assert.AreEqual(8, lightsLit);
        }

        [TestMethod]
        public void Thousand_lights_are_on_part1()
        {
            var lightsLit = _houseDecorator.TurnOnChristmasLights(new List<string> { "toggle 0,0 through 999,0" });
            Assert.AreEqual(1000, lightsLit);
        }

        [TestMethod]
        public void Zero_lights_are_on_part1()
        {
            var lightsLit = _houseDecorator.TurnOnChristmasLights(new List<string> { "turn off 499,499 through 500,500" });
            Assert.AreEqual(0, lightsLit);
        }


        [TestMethod]
        public void Answer_input_part1()
        {
            var instructions = File.ReadAllLines("../../../Day6_input.txt").ToList();
            var lightsLit = _houseDecorator.TurnOnChristmasLights(instructions);
            Assert.AreEqual(569999, lightsLit);
        }

        [TestMethod]
        public void Brightness_is_One_part2()
        {
            var brightness = _houseDecorator.ChangeBrightness(new List<string> { "turn on 0,0 through 0,0" });
            Assert.AreEqual(1, brightness);
        }

        [TestMethod]
        public void Brightness_is_Two_Million_part2()
        {
            var brightness = _houseDecorator.ChangeBrightness(new List<string> { "toggle 0,0 through 999,999" });
            Assert.AreEqual(2000000, brightness);
        }
        [TestMethod]
        public void Brightness_is_3_part2()
        {
            var brightness = _houseDecorator.ChangeBrightness(new List<string> { "turn on 0,0 through 0,0","toggle 0,1 through 0,1", "turn off 0,0 through 0,0" });
            Assert.AreEqual(2, brightness);
        }

        [TestMethod]
        public void Answer_input_part2()
        {
            var instructions = File.ReadAllLines("../../../Day6_input.txt").ToList();
            var lightsLit = _houseDecorator.ChangeBrightness(instructions);
            Assert.AreEqual(17836115, lightsLit);
        }

    }
}
