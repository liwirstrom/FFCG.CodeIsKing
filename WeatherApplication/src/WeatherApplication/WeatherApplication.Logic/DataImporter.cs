using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using WeatherApplication.Models;

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

		public void SaveInLocalDatabaseUsingEF(List<SimpleStation> stationList)
		{
			//using (var db = new WeatherContext())
			//{
			//	db.Stations.AddRange(stationList);
			//	db.SaveChanges();
			//}
		}

		public void SaveInLocalDatabase(List<SimpleStation> stationList)
		{
			var conncectionString = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=WeatherAPI;Integrated Security=SSPI;Trusted_Connection=yes;";
			var connection = new SqlConnection(conncectionString);
			connection.Open();
			int i = 0;
			foreach (var station in stationList)
			{
				var command = connection.CreateCommand();
				command.CommandText = $"INSERT INTO Stations VALUES (" +
										$"'{station.Id}', '{station.Name}', " +
										$"{station.Longitude.ToString().Replace(",", ".")}, " +
										$"{station.Latitude.ToString().Replace(",", ".")}, " +
										$"{station.Altitude.ToString().Replace(",", ".")});";

				command.ExecuteNonQuery();
				i++;
				var progress = (decimal)i / stationList.Count;

				Console.Write($"\r{progress:P}");
			}


				//"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		}

		public void SaveInLocalTextFile(List<SimpleStation> stationList, string filename)
		{
			var stationJsonArray = JsonConvert.SerializeObject(stationList);
			System.IO.File.WriteAllText(filename, stationJsonArray);
		}

	}
}
