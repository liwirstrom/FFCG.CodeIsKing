using Microsoft.EntityFrameworkCore;
using WeatherApplication.Models;

namespace WeatherApplication.Api.Data
{
	public class WeatherContext : DbContext
    {
		public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
		{
		}

		public DbSet<SimpleStation> Stations { get; set; }
	}
}

