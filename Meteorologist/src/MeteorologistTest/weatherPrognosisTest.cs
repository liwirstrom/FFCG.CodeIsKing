using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeteorologistLogic;
using System.Collections.Generic;

namespace MeteorologistTest
{
    [TestClass]
    public class WeatherProgonosisTest
    {
        private string _testCsvFile;
        private FileReader _fileReader;
        private Meteorologist _meteorologist;

        [TestInitialize]
        public void SetUp()
        {
            _fileReader = new FileReader();
            _meteorologist = new Meteorologist();
        }

        [TestMethod]
        public void Should_Save_First_Time_Temperature_Below_Zero()
        {
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\Meteorologist\testTemperatureData.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            TemperatureData firstSubZero = _meteorologist.GetFirstBelowZero(temperatureList);
            DateTime correctFirstBelowZero = new DateTime(2017, 10, 28, 11, 30, 8);
            Assert.AreEqual(correctFirstBelowZero, firstSubZero.TimeStamp);
            Assert.AreEqual(-0.5, firstSubZero.Temperature);
        }

        [TestMethod]
        public void Should_Not_Crash_When_Subzero_Is_Missing()
        {
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\Meteorologist\testNoSubZero.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            TemperatureData firstSubZero = _meteorologist.GetFirstBelowZero(temperatureList);
            Assert.IsNull(firstSubZero);
        }

        [TestMethod]
        public void Should_Save_Coldest_Temperature()
        {
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\Meteorologist\testTemperatureData.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            TemperatureData lowestTemperature = _meteorologist.GetColdestTemperature(temperatureList);
            DateTime _lowestTemperature = new DateTime(2017, 10, 28, 11, 35, 44);
            Assert.AreEqual(_lowestTemperature, lowestTemperature.TimeStamp);
            Assert.AreEqual(-1, lowestTemperature.Temperature);
        }

        [TestMethod]
        public void Should_Save_First_Instance_Of_Lowest_Temperature()
        {
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\Meteorologist\testTemperatureData.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            TemperatureData lowestTemperature = _meteorologist.GetColdestTemperature(temperatureList);
            DateTime _lowestTemperature = new DateTime(2017, 10, 28, 11, 35, 45);
            Assert.AreNotEqual(_lowestTemperature, lowestTemperature);
        }

        [TestMethod]
        public void Should_Save_Warmest_Temperature()
        {
            DateTime _warmestTemperature = new DateTime(2017, 10, 28, 12, 15, 44);
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\Meteorologist\testTemperatureData.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            TemperatureData lowestTemperature = _meteorologist.GetColdestTemperature(temperatureList);
        }

        [TestMethod]
        public void Should_Calculate_Correct_Mean()
        {
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\Meteorologist\testTemperatureData.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            double mean = _meteorologist.GetMeanTemperature(temperatureList);
            double meanTemperature = 25.5/8;
            Assert.AreEqual(meanTemperature,mean);
        }

        [TestMethod]
        public void Unix_TimeStamp_Gives_Correct_Date()
        {
            TemperatureData tempObject = new TemperatureData("1511966889", "1", 1);
            DateTime correctDatetime = new DateTime(2017,11,29,15,48,9);
            Assert.AreEqual(correctDatetime,tempObject.TimeStamp);

        }

    }
}
