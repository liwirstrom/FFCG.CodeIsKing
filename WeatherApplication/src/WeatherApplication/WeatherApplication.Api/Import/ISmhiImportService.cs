using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Import
{
	public interface IWeatherImportService
    {
		StationsApiModel GetAllStations();
	    Task<List<string>> SaveHistoricalAirTemperatures(string line);
    }
}
