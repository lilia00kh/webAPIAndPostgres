﻿using System;
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
            throw new NotImplementedException();
        }

        public async Task UpdateWeather(WeatherDto weatherDto)
        {
            throw new NotImplementedException();
        }

        public async Task CreateWeather(WeatherDto weatherDto)
        {
            throw new NotImplementedException();
        }

        public async Task<WeatherDto> GetWeatherById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
