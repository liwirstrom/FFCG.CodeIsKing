using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WeatherApplication.Models;

namespace WeatherApplication.Data
{
	public class WeatherContext : DbContext
    {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Initial Catalog = WeatherAPI; Integrated Security = SSPI; Trusted_Connection = yes;");
		}

		public DbSet<SimpleStation> Stations { get; set; }
	}
}

