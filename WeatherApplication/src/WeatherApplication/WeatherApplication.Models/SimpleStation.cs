using System.Collections.Generic;

namespace WeatherApplication.Models
{
	public class SimpleStation
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Altitude { get; set; }
	    public virtual ICollection<TemperatureData> Temperatures { get; set; }
	}
}
