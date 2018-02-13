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
		[Test]
		public void Should_Be_Able_To_Get_Stations()
		{
			var context = new WeatherContext();
			var station = context.Stations.First();
		}
	}
}
