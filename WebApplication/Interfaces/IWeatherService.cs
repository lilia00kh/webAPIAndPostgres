using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL.DomainModels;
using WebApplication.DTO;

namespace WebApplication.Interfaces
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherDomainModel>> GetWeathers();
        Task DeleteWeatherById(Guid id);
        Task UpdateWeather(WeatherDomainModel weatherDomainModel);
        Task CreateWeather(WeatherDomainModel weatherDomainModel);
        Task<WeatherDomainModel> GetWeatherById(Guid id);
    }
}
