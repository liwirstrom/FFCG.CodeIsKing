using System;
using System.Collections.Generic;
using System.Text;

namespace MeteorologistLogic.DataModels
{
    public class SimpleStation
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
