using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MeteorologistLogic.DataModels;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

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

                foreach (var line in File.ReadLines(file))
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
                        // TODO write to file? 
                        Console.WriteLine($"Did not create temperature object on row number {rowNr}");
                    }
                    rowNr++;
                }
                List<TemperatureData> SortedTemperatureList = temperatureList.OrderBy(o => o.TimeStamp).ToList();
                return SortedTemperatureList;
            }
            catch (FileNotFoundException exception)
            {
                throw new FileNotFoundException($"Can not find file. Raised exception {exception}");
            }

        }

        public async Task<List<SimpleStation>> ReadAirTempRespons(Task<HttpResponseMessage> responseTask)
        {
            List<SimpleStation> simpleStationList = new List<SimpleStation>();
            var responseMessage = await responseTask;
            var contentString = await responseMessage.Content.ReadAsStringAsync();
            var apiModel = JsonConvert.DeserializeObject<LufttemperaturApiSvar>(contentString);
            foreach (var station in apiModel.station)
            {
                var simpleStation = new SimpleStation() {
                                        Name = station.name,
                                        Id = station.id,
                                        Latitude = station.latitude,
                                        Longitude = station.longitude};

                simpleStationList.Add(simpleStation);
            }

            return simpleStationList;
        }
    }
}
