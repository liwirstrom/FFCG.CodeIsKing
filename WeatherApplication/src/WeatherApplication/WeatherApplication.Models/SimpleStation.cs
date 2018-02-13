using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApplication.Models
{
    public class SimpleStation
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Altitude { get; set; }
    }
}
