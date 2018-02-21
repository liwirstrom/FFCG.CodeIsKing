namespace WeatherApplication.Models
{
	public class StationsApiModel
    {
        public Link[] link { get; set; }
        public Station[] station { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Station
    {
        public string name { get; set; }
        public int id { get; set; }
        public float height { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public Link[] link { get; set; }
    }

    public class StationApiModel
    {
        public string key { get; set; }
        public long updated { get; set; }
        public string title { get; set; }
        public long from { get; set; }
        public long to { get; set; }
        public Link[] link { get; set; }
        public Period[] period { get; set; }
    }

    public class Period
    {
        public Link[] link { get; set; }
    }


    public class StationAirTempApiModel
    {
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public Link[] link { get; set; }
    }

}
