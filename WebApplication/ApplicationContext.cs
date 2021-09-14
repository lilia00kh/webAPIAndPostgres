using Microsoft.EntityFrameworkCore;
using WebApplication.DTO;

namespace WebApplication
{
    public class ApplicationContext : DbContext
    {
        public DbSet<WeatherForecastDTO> WeatherForecasts { get; set; }
        public DbSet<WeatherAndCityDTO> WeathersAndCities { get; set; }
        public DbSet<CityDTO> Cities { get; set; }

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
