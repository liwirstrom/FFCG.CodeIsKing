using Newtonsoft.Json;

namespace WeatherApplication.Models
{
	public class StationsApiModel
	{
		[JsonProperty("station")]
		public Station[] Station { get; set; }
	}

	public class Station
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("height")]
		public float Height { get; set; }
		[JsonProperty("latitude")]
		public float Latitude { get; set; }
		[JsonProperty("longitude")]
		public float Longitude { get; set; }
	}

}
