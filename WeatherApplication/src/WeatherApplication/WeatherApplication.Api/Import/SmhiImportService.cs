using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApplication.Api.Data;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Import
{
	public class SmhiImportService : IStationImportService
	{
		private readonly WeatherContext _db;
		private readonly IAppSettings _appSettings;

		public SmhiImportService(WeatherContext db, IAppSettings appSettings)
		{

			_db = db;
			_appSettings = appSettings;
		}

		public void SaveAll()
		{
			var httpClient = new HttpClient();
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
	}
}
