using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Data;

namespace WeatherApplication.Test.Data
{
	[TestFixture]
	public class WeatherContextTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void Should_Be_Able_To_Get_Stations()
		{
			var random = new Random();
			var station1 = new Models.SimpleStation
			{
				Id = Guid.NewGuid().ToString(),
				Altitude = (float)random.NextDouble(),
				Latitude = (float)random.NextDouble(),
				Longitude = (float)random.NextDouble(),
				Name = "TEST1"
			};

			using (var context = new WeatherContext())
			{
				context.Stations.Add(station1);

				context.SaveChanges();
			}

			using (var context = new WeatherContext())
			{
				var station2 = context.Stations.First(s => s.Id == station1.Id);
			}

			//var context = new WeatherContext();
			//context.Database.M
			//var station = context.Stations.First();
		}
	}
}
