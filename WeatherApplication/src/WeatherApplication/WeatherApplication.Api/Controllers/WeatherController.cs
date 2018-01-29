using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApplication.Logic.DataModel;

namespace WeatherApplication.Api.Controllers
{
    public class StationViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        [HttpGet]
        public List<StationViewModel> Get()
        {
            string path = @"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\WeatherApplication\src\Data\stations.json";

            var simpleStationJson = System.IO.File.ReadAllText(path);

            var simpleStations = JsonConvert.DeserializeObject<List<SimpleStation>>(simpleStationJson);

            var viewStations = new List<StationViewModel>();

            foreach (var simpleStation in simpleStations)
            {
                viewStations.Add(new StationViewModel()
                {
                    Id = simpleStation.Id,
                    Name = simpleStation.Name
                });
            }

            return viewStations;
        }

        [HttpGet("{id}")]
        public SimpleStation Get(string id)
        {
            string path = @"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\WeatherApplication\src\Data\stations.json";

            var json = System.IO.File.ReadAllText(path);

            var stations = JsonConvert.DeserializeObject<List<SimpleStation>>(json);

            return stations.FirstOrDefault(x => x.Id == id);
        }
    }
}