using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Models;

namespace WebApplication.Configuration
{
    public class Configuration 
    {
        private static readonly ApplicationContext _db = new ApplicationContext();
        public static void SeedData()
        {
            SeedWeathers();
            SeedCities();
            SeedWeathersAndCities();
        }

        private static void SeedWeathersAndCities()
        {
            var weatherAndCities = new List<WeatherAndCity>()
            {

                new WeatherAndCity
                {
                    Id = new Guid("c97454a7-cf3e-4a4c-99e1-ba1448320914"),
                    WeatherId = new Guid("b09eafe5-0c22-4417-bf21-39386210f6ed"),
                    CityId = new Guid("46277fc8-5aec-4c74-9ea9-9afd20da5823")
                },
                new WeatherAndCity
                {
                    Id = new Guid("bf081a5d-89d2-49f2-98dd-1803ca79c15c"),
                    WeatherId = new Guid("f29efb0e-77d2-4bc1-a339-075ac12c05f2"),
                    CityId = new Guid("d9ed4be1-239e-435c-bdf9-24fda65828f0")
                },
                new WeatherAndCity
                {
                    Id = new Guid("4e1ec4a9-2937-4158-b9c3-76f0b79b45cc"),
                    WeatherId = new Guid("17f16b75-dbd4-4de5-82c4-945d8f706daf"),
                    CityId = new Guid("d9ed4be1-239e-435c-bdf9-24fda65828f0")
                }
            };
            foreach (var weatherAndCity in weatherAndCities.Where(city => _db.WeathersAndCities.FirstOrDefault(x => x.Id == city.Id) == null))
            {
                _db.WeathersAndCities.Add(weatherAndCity);
                _db.SaveChanges();
            }
        }

        private static void SeedCities()
        {
            var cities = new List<City>()
            {

                    new City
                    {
                        Id = new Guid("46277fc8-5aec-4c74-9ea9-9afd20da5823"),
                        Name = "Lviv"
                    },
                    new City
                    {
                        Id = new Guid("d9ed4be1-239e-435c-bdf9-24fda65828f0"),
                        Name = "Horodok"
                    }
            };
            foreach (var city in cities.Where(city => _db.Cities.FirstOrDefault(x => x.Id == city.Id) == null))
            {
                _db.Cities.Add(city);
                _db.SaveChanges();
            }
        }

        private static void SeedWeathers()
        {
            var weatherForecasts = new List<WeatherForecast>()
            {
                new WeatherForecast
                {
                    Id = new Guid("b09eafe5-0c22-4417-bf21-39386210f6ed"),
                    Date = new DateTime(2021, 1, 10),
                    TemperatureC = 30,
                    Summary = "Hot"
                },
                new WeatherForecast
                {
                    Id = new Guid("f29efb0e-77d2-4bc1-a339-075ac12c05f2"),
                    Date = new DateTime(2021, 1, 10),
                    TemperatureC = -30,
                    Summary = "Cold"
                },
                new WeatherForecast
                {
                    Id = new Guid("17f16b75-dbd4-4de5-82c4-945d8f706daf"),
                    Date = new DateTime(2021, 1, 11),
                    TemperatureC = -28,
                    Summary = "Cold"
                }
            };
            foreach (var weatherForecast in weatherForecasts.Where(weatherForecast => _db.WeatherForecasts.FirstOrDefault(x => x.Id == weatherForecast.Id) == null))
            {
                _db.WeatherForecasts.Add(weatherForecast);
                _db.SaveChanges();
            }
        }

    }
}
