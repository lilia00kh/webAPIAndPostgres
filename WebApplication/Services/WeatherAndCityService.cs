using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL.DomainModels;
using DL.Interfaces;
using WebApplication.DTO;
using WebApplication.Interfaces;

namespace WebApplication.Services
{
    public class WeatherAndCityService : IWeatherAndCityService
    {
        private readonly IWeatherAndCityRepository _weatherAndCityRepository;

        public WeatherAndCityService(IWeatherAndCityRepository weatherAndCityRepository)
        {
            _weatherAndCityRepository = weatherAndCityRepository ?? throw new ArgumentNullException(nameof(weatherAndCityRepository));
        }
        public async Task<IEnumerable<WeatherAndCityDomainModel>> GetWeathersAndCities()
        {
            return await _weatherAndCityRepository.GetAllWeathersAndCities();
        }

        public async Task DeleteWeatherAndCityById(Guid id)
        {
            await _weatherAndCityRepository.DeleteById(id);
        }

        public async Task UpdateWeatherAndCity(WeatherAndCityDomainModel weatherAndCityDomainModel)
        {
            await _weatherAndCityRepository.Update(weatherAndCityDomainModel);
        }

        public async Task CreateWeatherAndCity(WeatherAndCityDomainModel weatherAndCityDomainModel)
        {
            await _weatherAndCityRepository.Create(weatherAndCityDomainModel);
        }

        public async Task<WeatherAndCityDomainModel> GetWeatherAndCityById(Guid id)
        {
            return await _weatherAndCityRepository.GetById(id);
        }
    }
}
