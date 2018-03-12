using System.Collections.Generic;
using System.Linq;
using WeatherApplication.Api.Data;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Repositories
{
	public class WeatherStationRepository : IWeatherStationRepository
	{
		private readonly WeatherContext _db;

		public WeatherStationRepository(WeatherContext db)
		{
			_db = db;
		}
		public IEnumerable<SimpleStation> All()
		{
			return _db.Stations.ToList();
		}

		public IEnumerable<TemperatureData> GetTemperaturesByStationId(string id, int page = 1, int pageSize = 50)
		{

			return _db.Temperatures
				.Where(t => t.StationId == id)
				.OrderByDescending(t => t.Date)
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();
		}

		public IEnumerable<TemperatureData> GetSpecificTemperatureByStation(string id, string date)
		{
			return _db.Temperatures
				.Where(t => t.StationId == id && t.Date.ToString("yy-MM-dd") == date)
				.ToList();
		}

		public SimpleStation Load(string id)
		{
			return _db.Stations.FirstOrDefault(x => x.Id == id);
		}

		public SimpleStation Save(SimpleStation station)
		{
			_db.Stations.Add(station);
			_db.SaveChanges();

			return station;
		}
	}
}
