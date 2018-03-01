using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using WeatherApplication.Models;

namespace WeatherApplicationTemperatureAPI
{
	public class Program
    {
        public static void Main(string[] args)
        {

			var temperatureController = new TemperatureController();
			temperatureController.SaveHistoricalTemperaturedata("102170");
			Console.WriteLine("Succesful api call");

		}
    }

	public class TemperatureController
	{
		public async void SaveHistoricalTemperaturedata(string station)
		{
			var httpClient = new HttpClient();
			var smhiClient = new SmhiHistoricalTemperatureImport();
			var temperatureList = new List<TemperatureData>();

			const string baseApiString = "https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1/station/{stationId}/period/corrected-archive/data.csv";
			var apiString = baseApiString.Replace("{stationId}", station);

			using (var response = httpClient.GetStreamAsync(apiString).Result)
			{
				var streamReader = new StreamReader(response);
				streamReader = smhiClient.SkipLines(10, streamReader);
				while (!streamReader.EndOfStream)
				{
					var line = await streamReader.ReadLineAsync();
					var temperature = smhiClient.CreateTemperatureObject(line);
					temperatureList.Add(temperature);
				}
			}
		}
	}

	public class SmhiHistoricalTemperatureImport
	{
		public StreamReader SkipLines(int linesToSkip, StreamReader stream)
		{
			for (var i = 0; i < linesToSkip; i++)
			{
				stream.ReadLineAsync();
			}

			return stream;
		}

		public TemperatureData CreateTemperatureObject(string line)
		{
			var splitString = line.Split(";");
			var splitDate = Array.ConvertAll(splitString[0].Split("-"), int.Parse);
			var splitTime = Array.ConvertAll(splitString[1].Split(":"), int.Parse);
			var temperatureData = new TemperatureData() {
				Date = new DateTime(splitDate[0], splitDate[1], splitDate[2], splitTime[0], splitTime[1], splitTime[2]),
				AirTemperature = double.Parse(splitString[2]),
				Quality = splitString[3]};

			return temperatureData;
		}

	}
}
