using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Api.Repositories;

namespace WeatherApplication.Api.Controllers
{
	[Route("api/[controller]")]
	public class WeatherController : Controller
	{

		private readonly IWeatherStationRepository _repository;

		public WeatherController(IWeatherStationRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_repository.All().OrderBy(x => x.Name).ToList());
		}

		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			try
			{
				return Ok(_repository.Load(id));
			}
			catch (Exception)
			{
				return NotFound();
			}
		}

		[HttpGet("{id}/temperatures")]
		public IActionResult GetTemperatures(string id)
		{
			var readings = _repository.GetTemperaturesByStationId(id);

			var temperatures = readings.Select(temperatureData => new TemperatureReadingViewModel
			{
				Date = temperatureData.Date,
				Temperature = temperatureData.AirTemperature
			});

			return Ok(temperatures);
		}

		[HttpGet("{id}/temperatures/{date}")]
		public IActionResult GetSpecifikDayTemperature(string id, string date)
		{
			return Ok(_repository.GetSpecificTemperatureByStation(id,date));
		}
	}

	public class TemperatureReadingViewModel
	{
		public DateTime Date { get; set; }
		public double Temperature { get; set; }
	}
}