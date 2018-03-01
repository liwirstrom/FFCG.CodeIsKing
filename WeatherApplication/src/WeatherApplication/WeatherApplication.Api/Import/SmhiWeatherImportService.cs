using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApplication.Api.Data;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Import
{
	public class SmhiWeatherImportService : IWeatherImportService
	{
		private readonly WeatherContext _db;
		private readonly IAppSettings _appSettings;
		private HttpClient httpClient;

		public SmhiWeatherImportService(WeatherContext db, IAppSettings appSettings)
		{
			httpClient = new HttpClient();
			_db = db;
			_appSettings = appSettings;
		}

		public void SaveAllStations()
		{
			var simpleStationList = new List<SimpleStation>();
			var apiString = _appSettings.Get("ApiEndpoints", "SmhiStations");
			var response = httpClient.GetStringAsync(apiString).Result;

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

			_db.Stations.AddRange(simpleStationList);
			_db.SaveChanges();
		}

		public async void SaveHistoricalAirTemperatures(string station)
		{

			var temperatureList = new List<TemperatureData>();

			var baseApiString = _appSettings.Get("ApiEndpoints", "HistoricalStationTemperatures");
			var apiString = baseApiString.Replace("{stationId}", station);

			using (var response = httpClient.GetStreamAsync(apiString).Result)
			{
				var streamReader = new StreamReader(response);
				streamReader = SkipLines(10, streamReader);
				while (!streamReader.EndOfStream)
				{
					var line = await streamReader.ReadLineAsync();
					var temperature = CreateTemperatureObject(line, station);
					temperatureList.Add(temperature);
				}
			}
		}

		private StreamReader SkipLines(int linesToSkip, StreamReader stream)
		{
			for (int i = 0; i < linesToSkip; i++)
			{
				stream.ReadLineAsync();
			}

			return stream;
		}
		private TemperatureData CreateTemperatureObject(string line, string stationId)
		{
			var splitString = line.Split(";");
			var splitDate = Array.ConvertAll(splitString[0].Split("-"), int.Parse);
			var splitTime = Array.ConvertAll(splitString[1].Split(":"), int.Parse);
			var temperatureData = new TemperatureData()
			{
				Date = new DateTime(splitDate[0], splitDate[1], splitDate[2], splitTime[0], splitTime[1], splitTime[2]),
				AirTemperature = Double.Parse(splitString[2]),
				Quality = splitString[3],
				StationId = stationId
			};

			return temperatureData;
		}
	}
}
