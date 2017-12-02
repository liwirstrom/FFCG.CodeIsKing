using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeteorologistLogic
{
    public class Meteorologist
    {
        public TemperatureData GetFirstBelowZero(List<TemperatureData> temperatureList)
        {
            return temperatureList.Where(temperatureObject => temperatureObject.Temperature < 0.0).FirstOrDefault();

        }
        public TemperatureData GetWarmestTemperature(List<TemperatureData> temperatureList)
        {
            return temperatureList.OrderByDescending(temperatureObject => temperatureObject.Temperature).FirstOrDefault();
            //TemperatureData warmestTemperatureObject = new TemperatureData();
            //double warmestTemperature = 273.15*-1;
            //foreach (var temperatureObject in temperatureList)
            //{
            //    if (temperatureObject.Temperature > warmestTemperature)
            //    {
            //        warmestTemperature = temperatureObject.Temperature;
            //        warmestTemperatureObject = temperatureObject;
            //    }
            //}

            //return warmestTemperatureObject;
        }

        public TemperatureData GetColdestTemperature(List<TemperatureData> temperatureList)
        {

            return temperatureList.OrderBy(temperatureObject => temperatureObject.Temperature).FirstOrDefault();

            //TemperatureData coldestTemperatureObject = new TemperatureData();
            //double coldestTemperature = double.MaxValue;
            //foreach (var temperatureObject in temperatureList)
            //{
            //    if (temperatureObject.Temperature < coldestTemperature)
            //    {
            //        coldestTemperature = temperatureObject.Temperature;
            //        coldestTemperatureObject = temperatureObject;
            //    }
            //}
            //if (coldestTemperature != 739)
            //{

            //    return coldestTemperatureObject;
            //}
            //else
            //{
            //    return null;
            //}
            
        }

        public Dictionary<string,double> GetMeanTemperature(List<TemperatureData> temperatureList)
        {
            Dictionary<string,double> meanValues = new Dictionary<string, double>();
            Dictionary<string,List<double>> dateTemperatures = new Dictionary<string, List<double>>();

            foreach (var temperatureObject in temperatureList)
            {
                string date = temperatureObject.TimeStamp.ToString("dddd,MMMM dd");
                if (!dateTemperatures.ContainsKey(date))
                {
                    List<double> temperatures = new List<double>();
                    temperatures.Add(temperatureObject.Temperature);
                    dateTemperatures.Add(date,temperatures);
                }
                else
                {
                    dateTemperatures[date].Add(temperatureObject.Temperature);
                }

            }

            foreach (var meanObject in dateTemperatures)
            {
                meanValues.Add(meanObject.Key, meanObject.Value.Average());
            }

            return meanValues;
        }

    }
}
