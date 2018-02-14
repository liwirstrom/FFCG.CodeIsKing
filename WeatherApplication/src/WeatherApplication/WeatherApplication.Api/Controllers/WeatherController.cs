using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Data;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Controllers
{
	[Route("api/[controller]")]
	public class WeatherController : Controller
	{
		[HttpGet]
		public IActionResult Get()
		{
			using (var context = new WeatherContext())
			{
				List<SimpleStation> viewStations = context.Stations.OrderBy(o => o.Name).ToList();
				return Ok(viewStations);
			}
		}

		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			try
			{
				using (var context = new WeatherContext())
				{
					var station = context.Stations.First(x => x.Id == id);
					return Ok(station);
				}
			}
			catch (System.Exception e)
			{
				return NotFound();
			}
		}
	}
}