using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Data;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Controllers
{
	[Route("api/[controller]")]
	public class WeatherController : Controller
	{
		//private string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=WeatherAPI;Integrated Security=SSPI;Trusted_Connection=yes;";

		[HttpGet]
		public IActionResult Get()
		{
			using (var context = new WeatherContext())
			{
				List<SimpleStation> viewStations = context.Stations.OrderBy(o => o.Name).ToList();
				return Ok(viewStations);
			}
		}

		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			try
			{
				//var Connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=WeatherAPI;Integrated Security=SSPI;Trusted_Connection=yes;");
				//Connection.Open();
				//var command = Connection.CreateCommand();
				//command.CommandText = "SELECT * FROM Stations WHERE Id = @IdParam ";

				//var param = new SqlParameter();
				//param.ParameterName = "@IdParam";
				//param.Value = id;
				//command.Parameters.Add(param);

				//var reader = command.ExecuteReader();
				//reader.Read();
				//var dataReaderWrapper = new SqlDataReaderWrapper(reader);
				//var weatherStation = StationViewModel.Create(dataReaderWrapper);

				//return Ok(weatherStation);
				using (var context = new WeatherContext())
				{
					var station = context.Stations.First(x => x.Id == id);
					return Ok(station);
				}
			}
			catch (System.Exception e)
			{
				return NotFound();
			}
		}

	}
}