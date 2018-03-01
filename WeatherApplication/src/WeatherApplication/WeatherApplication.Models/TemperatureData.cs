using System;

namespace WeatherApplication.Models
{
	public class TemperatureData
	{
		public DateTime Date { get; set; }
		public double AirTemperature { get; set; }
		public string Quality { get; set; }
		public string StationId { get; set; }
	}
}