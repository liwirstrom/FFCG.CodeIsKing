using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Models;

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
			catch (System.Exception)
			{
				return NotFound();
			}
		}
	}
}