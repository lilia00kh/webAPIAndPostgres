using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication
{
    public class ApplicationContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<WeatherAndCity> WeathersAndCities { get; set; }
        public DbSet<City> Cities { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=weathersdb;Username=postgres;Password=1234");
        }
    }
}
