using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WeatherApplication.Logic.DataModel;

namespace WeatherApplication.Logic
{
    public class DataImporter
    {
        private static string StationLink = "https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1/station/{stationId}.json";
        private static HttpClient httpClient;

        public DataImporter()
        {
            httpClient = new HttpClient();
        }
        public List<SimpleStation> CreateSimpleStationList(string uriString)
        {
            var simpleStationList = new List<SimpleStation>();

            var response = httpClient.GetStringAsync(uriString).Result;

            var stationApiAnswer = JsonConvert.DeserializeObject<StationsApiModel>(response);

            foreach (var station in stationApiAnswer.station)
            {
                var simpleStation = new SimpleStation()
                {
                    Name = station.name,
                    Id = station.id.ToString(),
                    Latitude = station.latitude,
                    Longitude = station.longitude,
                    Altitude = station.height
                };

                simpleStationList.Add(simpleStation);
            }

            return simpleStationList;
        }

        
    }
}
