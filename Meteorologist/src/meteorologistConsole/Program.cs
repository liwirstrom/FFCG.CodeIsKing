using MeteorologistLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meteorologistConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            Meteorologist meteorologist = new Meteorologist();
            WeatherResults weatherResults = new WeatherResults();

            Console.WriteLine("Hello! Please write the file where your temperature data is stored and separator in the file seperated with a ','.");
            string input = Console.ReadLine();
            string[] userInput = input.Split(',');

            List<TemperatureData> temperatureList = fileReader.CSVReader(userInput[0], Convert.ToChar(userInput[1]));

            weatherResults.WarmestDataEntry = meteorologist.GetWarmestTemperature(temperatureList);
            weatherResults.FirstSubZeroEntry = meteorologist.GetFirstBelowZero(temperatureList);
            weatherResults.MeanValues = meteorologist.GetMeanTemperature(temperatureList);
            weatherResults.ColdestDataEntry = meteorologist.GetColdestTemperature(temperatureList);

            Console.WriteLine(weatherResults.GetWeatherResult(temperatureList[0].TimeStamp, temperatureList[temperatureList.Count() - 1].TimeStamp));
            //Console.WriteLine($"The mean temperature between {temperatureList[0].TimeStamp.ToString("F")} and {temperatureList[temperatureList.Count()-1]} was {mean} degrees");
        }
    }
}
