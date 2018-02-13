using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApplication.Api.Controllers
{
	public class SimpleStationViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

		public static SimpleStationViewModel Create(IDataReader reader)
		{
			return new SimpleStationViewModel
			{
				Id = reader.GetProperty("id"),
				Name = reader.GetProperty("name")
			};
		}
    }

	public interface IDataReader
	{
		string GetProperty(string name);
	}

	public class SqlDataReaderWrapper : IDataReader
	{
		public SqlDataReaderWrapper(SqlDataReader dataReader)
		{
			_dataReader = dataReader;
		}

		private SqlDataReader _dataReader { get; }

		public string GetProperty(string name)
		{
			return _dataReader[name].ToString();
		}
	}

	public class StationViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public float Latitude { get; set; }
		public float Longitude { get; set; }
		public float Altitude { get; set; }

		public static StationViewModel Create(IDataReader reader)
		{
			return new StationViewModel
			{
				Id = reader.GetProperty("id"),
				Name = reader.GetProperty("name"),
				Latitude = float.Parse(reader.GetProperty("latitude")),
				Longitude = float.Parse(reader.GetProperty("longitude")),
				Altitude = float.Parse(reader.GetProperty("altitude")),
			};
		}
	}

	[Route("api/[controller]")]
	public class WeatherController : Controller
	{
		private string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=WeatherAPI;Integrated Security=SSPI;Trusted_Connection=yes;";

		[HttpGet]
		public IActionResult Get()
		{
			SqlConnection Connection = new SqlConnection(ConnectionString);
			Connection.Open();
			var command = Connection.CreateCommand();
			command.CommandText = "SELECT ID, Name FROM Stations ORDER BY Name";
			var reader = command.ExecuteReader();

			var viewStations = new List<SimpleStationViewModel>();

			var dataReaderWrapper = new SqlDataReaderWrapper(reader);

			while (reader.Read())
			{
				
				var weatherStation = SimpleStationViewModel.Create(dataReaderWrapper);

				viewStations.Add(weatherStation);
			}

			return Ok(viewStations);
		}

		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			try
			{
				var Connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=WeatherAPI;Integrated Security=SSPI;Trusted_Connection=yes;");
				Connection.Open();
				var command = Connection.CreateCommand();
				command.CommandText = "SELECT * FROM Stations WHERE Id = @IdParam ";

				var param = new SqlParameter();
				param.ParameterName = "@IdParam";
				param.Value = id;
				command.Parameters.Add(param);

				var reader = command.ExecuteReader();
				reader.Read();
				var dataReaderWrapper = new SqlDataReaderWrapper(reader);
				var weatherStation = StationViewModel.Create(dataReaderWrapper);

				return Ok(weatherStation);

			}
			catch (System.Exception e)
			{
				return NotFound();
			}
		}

	}
}