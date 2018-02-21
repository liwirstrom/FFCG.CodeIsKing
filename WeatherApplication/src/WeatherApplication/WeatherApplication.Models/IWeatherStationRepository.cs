using System.Collections.Generic;

namespace WeatherApplication.Models
{
	public interface IWeatherStationRepository
	{
		SimpleStation Load(string id);
		SimpleStation Save(SimpleStation station);
		IEnumerable<SimpleStation> All();
	}
}
