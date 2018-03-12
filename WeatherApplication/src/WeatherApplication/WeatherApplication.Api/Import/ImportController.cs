using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Api.Data;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Import
{
	[Route("api/import/smhi/stations")]
	public class ImportSmhiController : ControllerBase
	{
		private readonly WeatherContext _db;
		private readonly IWeatherImportService _importService;

		public ImportSmhiController(IWeatherImportService importService, WeatherContext db)
		{
			_importService = importService;
			_db = db;
		}

		[HttpPost]
		public IActionResult Post()
		{
			try
			{
				var weatherStations = _importService.GetAllStations();
				var simpleStationList = new List<SimpleStation>();

				foreach (var station in weatherStations.Station)
				{
					var simpleStation = new SimpleStation
					{
						Name = station.Name,
						Id = station.Id.ToString(),
						Latitude = station.Latitude,
						Longitude = station.Longitude,
						Altitude = station.Height
					};

					simpleStationList.Add(simpleStation);
				}

				_db.Stations.AddRange(simpleStationList);
				_db.SaveChanges();

				return Ok("Import complete");
			}
			catch (Exception)
			{
				return StatusCode(503);
			}
		}

		[Route("{stationdId}/temperature")]
		[HttpPost]
		public IActionResult PostHistoricalData(string stationdId)
		{
			try
			{
				var temperaturesList = new List<TemperatureData>();

				var temperatures = _importService.SaveHistoricalAirTemperatures(stationdId).Result;

				foreach (var temperatureString in temperatures)
				{
					var tempData = CreateTemperatureObject(temperatureString, stationdId);
					temperaturesList.Add(tempData);
				}

				_db.Temperatures.AddRange(temperaturesList);
				_db.SaveChanges();

				return Ok($"Saved air temperatures for station with id {stationdId}");
			}
			catch (Exception)
			{
				return StatusCode(503);
			}
		}

		private TemperatureData CreateTemperatureObject(string line, string stationId)
		{
			var splitString = line.Split(";");
			var splitDate = Array.ConvertAll(splitString[0].Split("-"), int.Parse);
			var splitTime = Array.ConvertAll(splitString[1].Split(":"), int.Parse);
			var temperatureData = new TemperatureData
			{
				Date = new DateTime(splitDate[0], splitDate[1], splitDate[2], splitTime[0], splitTime[1], splitTime[2]),
				AirTemperature = double.Parse(splitString[2]),
				Quality = splitString[3],
				StationId = stationId
			};

			return temperatureData;
		}
	}
}