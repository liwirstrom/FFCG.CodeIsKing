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
		public DbSet<TemperatureData> Temperatures { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			modelBuilder.Entity<TemperatureData>()
				.HasKey(t => t.Date);

		}
	}
}

