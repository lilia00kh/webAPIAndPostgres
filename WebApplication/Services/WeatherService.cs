using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL.DomainModels;
using DL.Interfaces;
using WebApplication.DTO;
using WebApplication.Interfaces;

namespace WebApplication.Services
{
    public class WeatherService: IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository ?? throw new ArgumentNullException(nameof(weatherRepository));
        }

        public async Task<IEnumerable<WeatherDomainModel>> GetWeathers()
        {
            return await _weatherRepository.GetAllWeathers();
        }

        public async Task DeleteWeatherById(Guid id)
        {
            await _weatherRepository.DeleteById(id);
        }

        public async Task UpdateWeather(WeatherDomainModel weatherDomainModel)
        {
            await _weatherRepository.Update(weatherDomainModel);
        }

        public async Task CreateWeather(WeatherDomainModel weatherDomainModel)
        {
            await _weatherRepository.Create(weatherDomainModel);
        }

        public async Task<WeatherDomainModel> GetWeatherById(Guid id)
        {
            return await _weatherRepository.GetById(id);
        }
    }
}
