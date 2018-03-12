using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Import
{
	public class SmhiWeatherImportService : IWeatherImportService
	{
		private readonly ApiEndpoints _endpoints;
		private readonly HttpClient _httpClient;

		public SmhiWeatherImportService(ApiEndpoints endpoints)
		{
			_endpoints = endpoints;
			_httpClient = new HttpClient();
		}

		public StationsApiModel GetAllStations()
		{
			var response = _httpClient.GetStringAsync(_endpoints.SmhiStations).Result;
			var stationApiAnswer = JsonConvert.DeserializeObject<StationsApiModel>(response);

			return stationApiAnswer;
		}

		public async Task<List<string>> SaveHistoricalAirTemperatures(string station)
		{
			var temperatureList = new List<string>();

			var baseApiString = _endpoints.HistoricalStationTemperatures;
			var apiString = baseApiString.Replace("{stationId}", station);

			using (var response = _httpClient.GetStreamAsync(apiString).Result)
			{
				var streamReader = new StreamReader(response);
				streamReader = SkipLines(10, streamReader);
				while (!streamReader.EndOfStream)
				{
					var line = await streamReader.ReadLineAsync();
					temperatureList.Add(line);
				}
			}

			return temperatureList;
		}

		private StreamReader SkipLines(int linesToSkip, StreamReader stream)
		{
			for (var i = 0; i < linesToSkip; i++) stream.ReadLineAsync();

			return stream;
		}
	}
}