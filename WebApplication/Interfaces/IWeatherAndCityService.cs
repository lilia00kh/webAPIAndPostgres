using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL.DomainModels;
using WebApplication.DTO;

namespace WebApplication.Interfaces
{
    public interface IWeatherAndCityService
    {
        Task<IEnumerable<WeatherAndCityDomainModel>> GetWeathersAndCities();
        Task DeleteWeatherAndCityById(Guid id);
        Task UpdateWeatherAndCity(WeatherAndCityDto weatherAndCityDto);
        Task CreateWeatherAndCity(WeatherAndCityDto weatherAndCityDto);
        Task<WeatherAndCityDto> GetWeatherAndCityById(Guid id);
    }
}
