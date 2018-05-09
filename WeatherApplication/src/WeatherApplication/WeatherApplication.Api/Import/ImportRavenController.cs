using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Import
{
	[Route("api/importraven/smhi/stations")]
	public class ImportRavenController : ControllerBase
    {
	    private readonly IWeatherImportService _importService;

	    public ImportRavenController(IWeatherImportService importService)
	    {
		    _importService = importService;
	    }


		[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost()]
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

				

		        return Ok("Import complete");
	        }
	        catch (Exception)
	        {
		        return StatusCode(503);
	        }
			return Ok();
        }

    }
}
