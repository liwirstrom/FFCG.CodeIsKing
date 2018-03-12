using System.Collections.Generic;
using Microsoft.AspNetCore.Rewrite.Internal.UrlMatches;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Repositories
{
	public interface IWeatherStationRepository
	{
		SimpleStation Load(string id);
		SimpleStation Save(SimpleStation station);
		IEnumerable<SimpleStation> All();
		IEnumerable<TemperatureData> GetTemperaturesByStationId(string id, int page = 1, int pageSize = 50);
		IEnumerable<TemperatureData> GetSpecificTemperatureByStation(string id, string date);
	}
}
