using System;
using System.Collections.Generic;
using System.Text;

namespace MeteorologistLogic
{
    public class LufttemperaturApiSvar
    {
        public string key { get; set; }
        public long updated { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string valueType { get; set; }
        public Link[] link { get; set; }
        public Stationset[] stationSet { get; set; }
        public Station[] station { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Stationset
    {
        public string key { get; set; }
        public object updated { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public Link[] link { get; set; }
    }

    public class Station
    {
        public string name { get; set; }
        public int id { get; set; }
        public float height { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string key { get; set; }
        public long updated { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public Link[] link { get; set; }
    }


}
