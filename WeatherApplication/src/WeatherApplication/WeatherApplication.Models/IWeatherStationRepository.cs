using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApplication.Models
{
	public interface IWeatherStationRepository
	{
		SimpleStation Load(string id);
		SimpleStation Save(SimpleStation station);
		IEnumerable<SimpleStation> All();
	}
}
