using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApplication.Api.Import
{
    public class StationsApiModel
    {
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


}
