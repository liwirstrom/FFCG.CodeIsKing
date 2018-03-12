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
			modelBuilder.Entity<TemperatureData>()
				.HasOne(t => t.Station)
				.WithMany(s => s.Temperatures)
				.HasForeignKey(t => t.StationId);

			modelBuilder.Entity<TemperatureData>()
				.HasKey(t => new {t.Date, t.StationId});
		}
	}
}