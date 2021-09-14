using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.DTO;

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
            var weatherAndCities = new List<WeatherAndCityDTO>()
            {

                new WeatherAndCityDTO
                {
                    WeatherId = new Guid("b09eafe5-0c22-4417-bf21-39386210f6ed"),
                    CityId = new Guid("46277fc8-5aec-4c74-9ea9-9afd20da5823")
                },
                new WeatherAndCityDTO
                {
                    WeatherId = new Guid("f29efb0e-77d2-4bc1-a339-075ac12c05f2"),
                    CityId = new Guid("d9ed4be1-239e-435c-bdf9-24fda65828f0")
                },
                new WeatherAndCityDTO
                {
                    WeatherId = new Guid("17f16b75-dbd4-4de5-82c4-945d8f706daf"),
                    CityId = new Guid("d9ed4be1-239e-435c-bdf9-24fda65828f0")
                }
            };
            foreach (var weatherAndCity in weatherAndCities
                .Where(city => _db.WeathersAndCities.FirstOrDefault(x => x.CityId == city.CityId && x.WeatherId == city.WeatherId) == null))
            {
                _db.WeathersAndCities.Add(weatherAndCity);
                _db.SaveChanges();
            }
        }

        private static void SeedCities()
        {
            var cities = new List<CityDTO>()
            {

                    new CityDTO
                    {
                        Id = new Guid("46277fc8-5aec-4c74-9ea9-9afd20da5823"),
                        Name = "Lviv"
                    },
                    new CityDTO
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
            var weatherForecasts = new List<WeatherForecastDTO>()
            {
                new WeatherForecastDTO
                {
                    Id = new Guid("b09eafe5-0c22-4417-bf21-39386210f6ed"),
                    Date = new DateTime(2021, 1, 10),
                    TemperatureC = 30,
                    Summary = "Hot"
                },
                new WeatherForecastDTO
                {
                    Id = new Guid("f29efb0e-77d2-4bc1-a339-075ac12c05f2"),
                    Date = new DateTime(2021, 1, 10),
                    TemperatureC = -30,
                    Summary = "Cold"
                },
                new WeatherForecastDTO
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
