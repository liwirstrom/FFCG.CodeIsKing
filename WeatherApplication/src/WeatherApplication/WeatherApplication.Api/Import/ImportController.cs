using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using WeatherApplication.Api.Data;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Import
{
	[Route("api/import/smhi/stations")]
	public class ImportSmhiController : Controller
    {
		private readonly IStationImportService _importService;
		public ImportSmhiController(IStationImportService importService)
		{
			_importService = importService;
		}

		[HttpPost]
		public IActionResult Post()
		{
			try
			{
				_importService.SaveAll();
				return Ok("Import complete");
			}
			catch (System.Exception)
			{

				return StatusCode(503);
			}
		}
	}
}
