using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Import
{
	[Route("api/import/smhi/stations")]
	public class ImportSmhiController : Controller
	{
		private readonly IWeatherImportService _importService;
		public ImportSmhiController(IWeatherImportService importService)
		{
			_importService = importService;
		}

		[HttpPost]
		public IActionResult Post()
		{
			try
			{
				_importService.SaveAllStations();
				return Ok("Import complete");
			}
			catch (System.Exception)
			{

				return StatusCode(503);
			}
		}

		[Route("{stationdId}/temperature")]
		[HttpPost]
		public IActionResult PostHistoricalData(string station)
		{
			try
			{
				_importService.SaveHistoricalAirTemperatures(station);
				return Ok($"Saved air temperatures for station with id {station}");
			}
			catch (System.Exception)
			{

				return StatusCode(503);
			}
		} 
	}
}
