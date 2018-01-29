using MeteorologistLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

/* WeatherData:
 * C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\WeatherData\temperatureData.csv
 * Test
 *  C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\WeatherData\testTemperatureData.csv
 *  C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\WeatherData\testNoSubZero.csv
 * */

namespace meteorologistConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            Meteorologist meteorologist = new Meteorologist();
            WeatherResults weatherResults = new WeatherResults();
            ApiReader apiReader = new ApiReader();

            //Console.WriteLine("Hello! Please write the file where your temperature data is stored and separator in the file seperated with a ','.");
            //string input = Console.ReadLine();
            //string[] userInput = input.Split(',');

            //List<TemperatureData> temperatureList = fileReader.CSVReader(userInput[0], Convert.ToChar(userInput[1]));

            //weatherResults.WarmestDataEntry = meteorologist.GetWarmestTemperature(temperatureList);
            //weatherResults.FirstSubZeroEntry = meteorologist.GetFirstBelowZero(temperatureList);
            //weatherResults.MeanValues = meteorologist.GetMeanTemperature(temperatureList);
            //weatherResults.ColdestDataEntry = meteorologist.GetColdestTemperature(temperatureList);

            //Console.WriteLine(weatherResults.GetWeatherResult(temperatureList[0].TimeStamp, temperatureList[temperatureList.Count() - 1].TimeStamp));

            var apiString = $"https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1.json";
            var response = apiReader.GetAsyncFromApi(apiString);
            var simpleStationList = fileReader.ReadAirTempRespons(response).GetAwaiter().GetResult();
            string stationJsonArray = JsonConvert.SerializeObject(simpleStationList);
            System.IO.File.WriteAllText(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\stations.json", stationJsonArray);
        }
    }
}
