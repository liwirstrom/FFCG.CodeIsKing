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
