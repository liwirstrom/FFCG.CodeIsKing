using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MeteorologistLogic
{
    public class FileReader
    {
        public List<TemperatureData> CSVReader(string file, char separator)
        {
            var rowNr = 0;
            List<TemperatureData> temperatureList = new List<TemperatureData>();
            try
            {

                foreach (var line in File.ReadLines(@file))
                {

                    var cleanLine = line.Replace("\"", string.Empty).Trim();
                    var values = cleanLine.Split(separator);
                    if (values.Length == 2 && rowNr > 0)
                    {
                        TemperatureData temperatureObject = new TemperatureData(values[0], values[1], rowNr);
                        temperatureList.Add(temperatureObject);
                    }
                    else
                    {
                        Console.WriteLine($"Did not create temperature object on row number {rowNr}");
                    }
                    rowNr++;
                }
                List<TemperatureData> SortedTemperatureList = temperatureList.OrderBy(o => o.TimeStamp).ToList();
                return SortedTemperatureList;
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine($"Can not find file. Raised exception {exception}");
                throw;
            }

        }
    }
}
