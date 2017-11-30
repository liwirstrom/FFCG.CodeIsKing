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
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\WeatherData\testTemperatureData.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            TemperatureData firstSubZero = _meteorologist.GetFirstBelowZero(temperatureList);
            DateTime correctFirstBelowZero = new DateTime(2017, 10, 28, 11, 30, 8);
            Assert.AreEqual(correctFirstBelowZero, firstSubZero.TimeStamp);
            Assert.AreEqual(-0.5, firstSubZero.Temperature);
        }

        [TestMethod]
        public void Should_Not_Crash_When_Subzero_Is_Missing()
        {
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\WeatherData\testNoSubZero.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            TemperatureData firstSubZero = _meteorologist.GetFirstBelowZero(temperatureList);
            Assert.IsNull(firstSubZero);
        }

        [TestMethod]
        public void Should_Save_Coldest_Temperature()
        {
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\WeatherData\testTemperatureData.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            TemperatureData lowestTemperature = _meteorologist.GetColdestTemperature(temperatureList);
            DateTime _lowestTemperature = new DateTime(2017, 10, 28, 11, 35, 44);
            Assert.AreEqual(_lowestTemperature, lowestTemperature.TimeStamp);
            Assert.AreEqual(-1, lowestTemperature.Temperature);
        }

        [TestMethod]
        public void Should_Save_First_Instance_Of_Lowest_Temperature()
        {
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\WeatherData\testTemperatureData.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            TemperatureData lowestTemperature = _meteorologist.GetColdestTemperature(temperatureList);
            DateTime _lowestTemperature = new DateTime(2017, 10, 28, 11, 35, 45);
            Assert.AreNotEqual(_lowestTemperature, lowestTemperature);
        }

        [TestMethod]
        public void Should_Save_Warmest_Temperature()
        {
            DateTime _warmestTemperature = new DateTime(2017, 10, 28, 12, 15, 44);
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\WeatherData\testTemperatureData.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            TemperatureData lowestTemperature = _meteorologist.GetColdestTemperature(temperatureList);
        }

        [TestMethod]
        public void Should_Save_Mean_For_Each_Day()
        {
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\WeatherData\testTemperatureData.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            Dictionary<string,double> meanDictionary = _meteorologist.GetMeanTemperature(temperatureList);

            Assert.IsTrue(meanDictionary.ContainsKey("Saturday,October 28"));
            Assert.IsTrue(meanDictionary.ContainsKey("Thursday,November 30"));
        }

        [TestMethod]
        public void Should_Calclate_Correct_Mean()
        {
            _testCsvFile = @"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\WeatherData\testTemperatureData.csv";
            List<TemperatureData> temperatureList = _fileReader.CSVReader(_testCsvFile, ';');
            Dictionary<string, double> meanDictionary = _meteorologist.GetMeanTemperature(temperatureList);

            double saturdayMean = meanDictionary["Saturday,October 28"];
            Assert.AreEqual(18.5 / 7,saturdayMean);
            double ThursdayMean = meanDictionary["Thursday,November 30"];
            Assert.AreEqual(7, ThursdayMean);
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
