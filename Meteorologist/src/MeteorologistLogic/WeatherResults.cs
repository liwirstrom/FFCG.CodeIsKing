using System;
using System.Collections.Generic;
using System.Text;

namespace MeteorologistLogic
{
    public class WeatherResults
    {
        public TemperatureData WarmestDataEntry { private get; set; }
        public TemperatureData ColdestDataEntry { private get; set; }
        public TemperatureData FirstSubZeroEntry { private get; set; }
        public Dictionary<string,double> MeanValues { private get; set; }

        public string GetWeatherResult(DateTime firstEntry, DateTime lastEntry)
        {
            var ResultString = $"The following result is based on temperatures between {firstEntry.ToString("F")} and {lastEntry.ToString("F")}" +
                $"\nThe highest temperature was {WarmestDataEntry.TimeStamp.ToString("F")}" +
                               $"\n{GetFirstSubZeroEntry()}\n{GetMeanOuput()}"
                               + $"\n{GetColdestEntry()}";
            //ResultString = ResultString.Replace("@", " " + System.Environment.NewLine);
            return ResultString;
        }

        private string GetFirstSubZeroEntry()
        {
            var firstSubZeroString = "";
            if (FirstSubZeroEntry == null)
            {
                firstSubZeroString += "There was no temperatures below zero in the data you provided";
            }
            else
            {
                firstSubZeroString += $"The first time the temperature was subzero was {FirstSubZeroEntry.TimeStamp.ToString("F")} and it was {FirstSubZeroEntry.Temperature} degrees.";
            }

            return firstSubZeroString;
        }

        private string GetColdestEntry()
        {
            return $"The coldest temperature was {ColdestDataEntry.Temperature} on {ColdestDataEntry.TimeStamp.ToString("F")}";
        }
        private string GetMeanOuput()
        {
            if (MeanValues!= null)
            {
                string returnString = "";
                foreach (var mean in MeanValues)
                {
                    returnString += $"The mean temperature was {mean.Value} degrees on {mean.Key}\n";
                }
                return returnString;
            }
            else
            {
                return "There was no mean value";
            }
        }
    }
}
