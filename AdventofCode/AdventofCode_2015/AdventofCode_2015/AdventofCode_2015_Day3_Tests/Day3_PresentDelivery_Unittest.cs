using System.Collections.Generic;
using AdventofCode_2015_Day3;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventofCode_2015_Day3_Tests
{
    [TestClass]
    public class Present_Deliver_Unittest
    {
        private FileReader _fileReader;

        private DeliveryCalculator _deliveryCalculator;

        [TestInitialize]
        public void Setup()
        {
            _fileReader = new FileReader();
            _deliveryCalculator = new DeliveryCalculator();
        }

        [TestMethod]
        public void Should_Deliver_To_2_Houses_part1()
        {
            var input = new List<string> {">"};
            var housesDeliveredTo = _deliveryCalculator.GetNumberOfHouses(input, 1);

            Assert.AreEqual(2, housesDeliveredTo);
        }

        [TestMethod]
        public void Should_Deliver_To_4_Houses_part1()
        {
            var input = new List<string> { "^>v<" };
            var housesDeliveredTo = _deliveryCalculator.GetNumberOfHouses(input, 1);

            Assert.AreEqual(4, housesDeliveredTo);
        }

        [TestMethod]
        public void Should_Deliver_To_2_Houses_again_part1()
        {
            var input = new List<string> { "^v^v^v^v^v" };
            var housesDeliveredTo = _deliveryCalculator.GetNumberOfHouses(input, 1);

            Assert.AreEqual(2, housesDeliveredTo);
        }

        [TestMethod]
        public void Answer_input_part1()
        {

            var input = _fileReader.ReadFile("../../../Day3_input.txt");
            var housesDeliveredTo = _deliveryCalculator.GetNumberOfHouses(input[0], 1);

            Assert.AreEqual(2565, housesDeliveredTo);
        }

        [TestMethod]
        public void Should_Deliver_To_3_Houses_part2()
        {
            var input = new List<string> { "^v" };
            var housesDeliveredTo = _deliveryCalculator.GetNumberOfHouses(input, 2);

            Assert.AreEqual(3, housesDeliveredTo);
        }

        [TestMethod]
        public void Should_Deliver_To_5_Houses_part2()
        {
            var input = new List<string> { "^v^v" };
            var housesDeliveredTo = _deliveryCalculator.GetNumberOfHouses(input, 2);

            Assert.AreEqual(5, housesDeliveredTo);
        }

        [TestMethod]
        public void Should_Deliver_To_3_Houses_again_part2()
        {
            var input = new List<string> { "^>v<" };
            var housesDeliveredTo = _deliveryCalculator.GetNumberOfHouses(input, 2);

            Assert.AreEqual(3, housesDeliveredTo);
        }

        [TestMethod]
        public void Should_Deliver_To_11_Houses_part2()
        {
            var input = new List<string> { "^v^v^v^v^v" };
            var housesDeliveredTo = _deliveryCalculator.GetNumberOfHouses(input, 2);

            Assert.AreEqual(11, housesDeliveredTo);
        }

        [TestMethod]
        public void Should_Deliver_To_6_Houses_part2()
        {
            var input = new List<string> { "^v>^>^v>" };
            var housesDeliveredTo = _deliveryCalculator.GetNumberOfHouses(input, 2);

            Assert.AreEqual(6, housesDeliveredTo);
        }

        [TestMethod]
        public void Answer_input_part2()
        {
            var input = _fileReader.ReadFile("../../../Day3_input.txt");
            var housesDeliveredTo = _deliveryCalculator.GetNumberOfHouses(input[0], 2);

            Assert.AreEqual(2639, housesDeliveredTo);
        }

    }
}
